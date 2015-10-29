using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using NHttp;
using System.IO;
using Newtonsoft.Json;

namespace AoC.Questionnaire
{
    class Program :
        Webserver
    {
        private static DirectoryInfo _base_directory;

        public Program(IPEndPoint endpoint, string base_directory) :
            base(endpoint)
        {
            Get["/regions"] = GetRegions;
            Get["/organisations"] = GetOrganisations;
            Post["/form"] = PostForm;
            Get["/admin"] = GetAdmin;
            Get["/admin.html"] = GetAdmin;
            Get["/admin/login"] = GetLogin;
            Get["/login.html"] = GetLogin;
            Post["/admin/login"] = PostLogin;
            Get["/admin/data"] = GetJsonData;
            Post["/admin/export"] = PostExportData;

            _base_directory = new DirectoryInfo(base_directory);
            foreach (var file in _base_directory.RecursiveFileSearch())
            {
                string f = file.Name;
                if (f == "index.html")
                    f = "";
                DirectoryInfo p = file.Directory;
                while (p.Name != _base_directory.Name)
                {
                    f = p.Name + "/" + f;
                    p = p.Parent;
                }
                Get["/" + f] = (r, e) => DefaultResponses.FileResponse(e, file.FullName);
            }
        }

        private static void GetRegions(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            DefaultResponses.Json(e, Db.Regions.Select(p => p.Value.Name).Distinct().OrderBy(p => p, StringComparer.OrdinalIgnoreCase));
        }

        private static void GetOrganisations(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            DefaultResponses.Json(e, Db.Organisations.Select(p => p.Value.Name).Distinct().OrderBy(p => p, StringComparer.OrdinalIgnoreCase));
        }

        private static void PostForm(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            var entry = new Model.AOCEntry();
            Console.WriteLine("Entry received");

            bool avail = false;
            int score = 0;
            int.TryParse(e.Request.Form["Score"] ?? string.Empty, out score);

            var a = e.Request.Form["Availability"];
            if (!string.IsNullOrEmpty(a))
            {
                a = a.ToLowerInvariant();
                avail = a == "checked" || a == "true";
            }

            entry.FirstName = e.Request.Form["FirstName"] ?? string.Empty;
            entry.LastName = e.Request.Form["LastName"] ?? string.Empty;
            entry.Email = e.Request.Form["Email"] ?? string.Empty;
            entry.Role = e.Request.Form["Role"] ?? string.Empty;
            entry.LineManager = e.Request.Form["LineManager"] ?? string.Empty;
            entry.Reason = e.Request.Form["Reason"] ?? string.Empty;
            entry.Answers = e.Request.Form["Answers"] ?? string.Empty;
            entry.Organisation = e.Request.Form["Organisation"] ?? string.Empty;
            entry.Region = e.Request.Form["Region"] ?? string.Empty;
            entry.Available = avail;
            entry.Score = score;
            entry.Answers = e.Request.Form["Answers"] ?? string.Empty;
            entry.Submitted = DateTime.UtcNow;

            Dictionary<string, object> errors = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(entry.FirstName) || entry.FirstName.Length < 2)
                errors["FirstName"] = "Please enter a first name";
            if (string.IsNullOrEmpty(entry.LastName) || entry.LastName.Length < 2)
                errors["LastName"] = "Please enter a last name";
            if (string.IsNullOrEmpty(entry.Email) || entry.Email.Length < 5)
                errors["Email"] = "Please enter an email address";
            else if (!entry.Email.ValidateEmail())
                errors["Email"] = "Please enter a valid email address";
            if (string.IsNullOrEmpty(entry.Role) || entry.Role.Length < 2)
                errors["Role"] = "Please enter a role";
            if (string.IsNullOrEmpty(entry.LineManager) || entry.LineManager.Length < 2)
                errors["LineManager"] = "Please enter the name of your line manager";
            if (string.IsNullOrEmpty(entry.Reason) || entry.Reason.Length < 2)
                errors["Reason"] = "Please tell us why you should be an Agent of Change";
            if (string.IsNullOrEmpty(entry.Organisation) || entry.Organisation.Length < 2)
                errors["Organisation"] = "Please select an organisation";
            if (string.IsNullOrEmpty(entry.Region) || entry.Region.Length < 2)
                errors["Region"] = "Please select a region";

            if (errors.Count > 0)
            {
                errors["result"] = false;
                DefaultResponses.Json(e, errors);
                Console.WriteLine("Failed entry: {0}", JsonConvert.SerializeObject(errors));
            }
            else
            {
                Db.AddEntry(entry);
                if (string.IsNullOrEmpty(Config.SuccessRedirect))
                    DefaultResponses.Json(e, new Dictionary<string, object>() { { "result", true } });
                else
                    DefaultResponses.RedirectResponse(e, Config.SuccessRedirect);
                Console.WriteLine("Successful entry from {0}", entry.Email);
            }
        }

        private static void GetAdmin(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            if (!Session.IsAuthenticated(e))
            {
                DefaultResponses.RedirectResponse(e, "/admin/login");
                return;
            }

            DefaultResponses.FileResponse(e, Path.Combine(_base_directory.FullName, "admin.html"));
        }

        private static void GetLogin(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            if (Session.IsAuthenticated(e))
                DefaultResponses.RedirectResponse(e, "/admin");
            else
                DefaultResponses.FileResponse(e, Path.Combine(_base_directory.FullName, "login.html"));
        }

        private static void PostLogin(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            Session.Authenticate(e,
                x =>
                {
                    DefaultResponses.RedirectResponse(x, "/admin");
                    Console.WriteLine("User successfully authenticated");
                }, x =>
                {
                    DefaultResponses.RedirectResponse(x, "/admin/login");
                    Console.WriteLine("User failed login");
                });
        }

        private static void GetJsonData(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            if (!Session.IsAuthenticated(e))
            {
                DefaultResponses.RedirectResponse(e, "/admin/login");
                return;
            }

            DefaultResponses.Json(e, Db.Entries);
        }

        private static void PostExportData(IDictionary<string, string> parameters, HttpRequestEventArgs e)
        {
            if (!Session.IsAuthenticated(e))
            {
                DefaultResponses.RedirectResponse(e, "/admin/login");
                return;
            }

            using (StringWriter sw = new StringWriter())
            {
                sw.Write("\"First name\",");
                sw.Write("\"Last name\",");
                sw.Write("\"Email\",");
                sw.Write("\"Role\",");
                sw.Write("\"Line Manager\",");
                sw.Write("\"Organisation\",");
                sw.Write("\"Region\",");
                sw.Write("\"Available\",");
                sw.Write("\"Score\",");
                sw.WriteLine("\"Reason\"");

                foreach (var entry in Db.Entries)
                {
                    sw.Write("\"" + entry.FirstName + "\",");
                    sw.Write("\"" + entry.LastName + "\",");
                    sw.Write("\"" + entry.Email + "\",");
                    sw.Write("\"" + entry.Role + "\",");
                    sw.Write("\"" + entry.LineManager + "\",");
                    sw.Write("\"" + entry.Organisation + "\",");
                    sw.Write("\"" + entry.Region + "\",");
                    sw.Write("\"" + entry.Available + "\",");
                    sw.Write("\"" + entry.Score + "\",");
                    sw.WriteLine("\"" + entry.Reason + "\"");
                }

                DefaultResponses.TextFile(e, sw.ToString(), "agents_of_change.csv", content_type: "text/csv");
            }
        }

        static void Main(string[] args)
        {
            Db.Initialize();
            var server = new Program(Config.Endpoint, Config.BaseDirectory);
            Console.WriteLine("Server started at {0}, using {1} as a base directory", Config.Endpoint, Config.BaseDirectory);

            Console.ReadLine();
        }
    }
}
