using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NHttp;
using System.Net;
using System.IO;

namespace AoC.Questionnaire
{
    public class Webserver
    {
		class Route :
            IEquatable<Route>
        {
            private static readonly Regex PathRegex = new Regex(@"\{(?<param>\S+)\}", RegexOptions.Compiled);

            private readonly string[] _param_names;

            public string Method
            {
                get;
                private set;
            }

            public string Path
            {
                get;
                private set;
            }

            public Action<IDictionary<string, string>, HttpRequestEventArgs> Action
            {
                get;
                private set;
            }

            public Regex Regex
            {
                get;
                private set;
            }

            public Route(string method, string path, Action<IDictionary<string, string>, HttpRequestEventArgs> action)
            {
                Method = method;
                Path = path;
                Action = action;

                var paramNames = new List<string>();
                Regex = new Regex("^" + PathRegex.Replace(path, m => { var p = m.Groups["param"].Value; paramNames.Add(p); return string.Format(@"(?<{0}>\S+)", p); }) + "$");
                _param_names = paramNames.ToArray();
            }

            public bool IsMatch(HttpRequestEventArgs e)
            {
                return e.Request.HttpMethod == Method && Regex.IsMatch(e.Request.Url.AbsolutePath);
            }

            public void Invoke(HttpRequestEventArgs e)
            {
                var match = Regex.Match(e.Request.Url.AbsolutePath);
                var parameters = _param_names.ToDictionary(k => k, k => match.Groups[k].Value, StringComparer.OrdinalIgnoreCase);
                Action.Invoke(parameters, e);
            }

            public bool Equals(Route other)
            {
                return Method == other.Method && Path == other.Path && ReferenceEquals(Action, other.Action);
            }
        }

        private readonly HttpServer _server;
        private readonly IDictionary<string, ICollection<Route>> _routes;

        public Webserver() :
			this(new IPEndPoint(IPAddress.Any, 80))
        {

        }

        public Webserver(IPEndPoint endpoint)
        {
            _routes = new Dictionary<string, ICollection<Route>>(StringComparer.OrdinalIgnoreCase);

            _server = new HttpServer();
            _server.EndPoint = endpoint;
            _server.RequestReceived += OnRequestReceived;
            _server.StateChanged += OnStateChanged;
            _server.UnhandledException += OnUnhandledException; ;
            _server.Start();

        }

        private void OnRequestReceived(object sender, HttpRequestEventArgs e)
        {
            Route route = null;
            var routes = _routes[e.Request.HttpMethod];
            if (routes != null && routes.Count > 0)
            {
                foreach (var r in routes)
                {
                    if (r.IsMatch(e))
                    {
                        route = r;
                        break;
                    }
                }
                if (route != null)
                {
                    route.Invoke(e);
                    return;
                }
            }

            DefaultResponses.NotFound(e);
        }

        private void OnUnhandledException(object sender, HttpExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            
        }

        protected RouteBuilder Get
        {
            get { return new RouteBuilder("GET", this); }
        }

        protected RouteBuilder Post
        {
            get { return new RouteBuilder("POST", this); }
        }

        protected RouteBuilder Put
        {
            get { return new RouteBuilder("PUT", this); }
        }

        protected RouteBuilder Delete
        {
            get { return new RouteBuilder("DELETE", this); }
        }

        protected RouteBuilder Options
        {
            get { return new RouteBuilder("OPTIONS", this); }
        }

        protected RouteBuilder Patch
        {
            get { return new RouteBuilder("PATCH", this); }
        }

        protected RouteBuilder Head
        {
            get { return new RouteBuilder("HEAD", this); }
        }

        protected class RouteBuilder
        {
            private readonly string _method;
            private readonly Webserver _server;

            public RouteBuilder(string method, Webserver server)
            {
                _method = method;
                _server = server;
            }

            public Action<IDictionary<string, string>, HttpRequestEventArgs> this[string path]
            {
                set { AddRoute(path, value); }
            }
            private void AddRoute(string path, Action<IDictionary<string, string>, HttpRequestEventArgs> value)
            {
                if (!_server._routes.ContainsKey(_method))
                    _server._routes[_method] = new HashSet<Route>();
                _server._routes[_method].Add(new Route(_method, path, value));
            }
        }

        public static class DefaultResponses
        {
            public static void NotFound(HttpRequestEventArgs e)
            {
                e.Response.StatusCode = 404;
                e.Response.StatusDescription = "NotFound";
                e.Response.ContentType = "text/html";
                e.Response.OutputStream.Write("<html><head><title>404 - Not Found</title></head><body><h1>404 Not found</h1></body></html>");
            }

            public static void Text(HttpRequestEventArgs e, string o, string content_type = "text/plain")
            {
                e.Response.StatusCode = 200;
                e.Response.ContentType = content_type;
                e.Response.OutputStream.Write(o);
            }

            public static void TextFile(HttpRequestEventArgs e, string o, string file_name, string content_type = "text/plain")
            {
                e.Response.StatusCode = 200;
                e.Response.ContentType = content_type;
                e.Response.Headers["Content-Disposition"] = "attachment; filename=\"" + file_name + "\"";
                e.Response.OutputStream.Write(o);
            }

            public static void Json(HttpRequestEventArgs e, object o)
            {
                e.Response.StatusCode = 200;
                e.Response.ContentType = "application/json";
                e.Response.OutputStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(o));
            }

            public static void FileResponse(HttpRequestEventArgs e, string file)
            {
                using (var f = File.OpenRead(file))
                {
                    e.Response.StatusCode = 200;
                    e.Response.ContentType = MimeTypes.GetMimeType(file);

                    Extensions.CopyTo(f, e.Response.OutputStream);
                }
            }

            public static void RedirectResponse(HttpRequestEventArgs e, string redirect)
            {
                e.Response.Redirect(redirect);
            }

            public static void FileResponse(HttpRequestEventArgs e, string file, string content_type, Func<string, string> replace)
            {
                using (var f = File.OpenRead(file))
                using (var sr = new StreamReader(f))
                using (var sw = new StreamWriter(e.Response.OutputStream))
                {
                    e.Response.StatusCode = 200;
                    e.Response.ContentType = content_type ?? MimeTypes.GetMimeType(file);
                    sw.Write(replace(sr.ReadToEnd()));
                }
            }
        }
    }
}
