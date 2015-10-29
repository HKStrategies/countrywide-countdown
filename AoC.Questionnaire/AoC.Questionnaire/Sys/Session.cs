using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using NHttp;

namespace AoC.Questionnaire
{
    public static class Session
    {
        class S
        {
            public DateTime LastAccessed = DateTime.UtcNow;
            public Dictionary<string, object> Values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            public T Get<T>(string key)
            {
                object o;
                if (Values.TryGetValue(key, out o))
                    return (T)o;
                return default(T);
            }
        }

        private static readonly ConcurrentDictionary<string, S> SESSIONS;
        private static readonly ThreadLocal<Random> RNG = new ThreadLocal<Random>(() => new Random());

        static Session()
        {
            SESSIONS = new ConcurrentDictionary<string, S>(StringComparer.OrdinalIgnoreCase);
        }

        private static S GetSession(HttpRequestEventArgs e)
        {
            HttpCookie cookie = null;
            S s = null;
            if (e.Request.Cookies.AllKeys.Contains("SESSION_ID"))
            {
                cookie = e.Request.Cookies["SESSION_ID"];
                if (!SESSIONS.TryGetValue(cookie.Value, out s))
                    s = null;
                else
                {
                    if (s.LastAccessed < DateTime.UtcNow.AddMinutes(-20))
                        s = null;
                    else
                        s.LastAccessed = DateTime.UtcNow;
                }
            }

            if (s == null)
            {
                byte[] buffer = new byte[32];
                string session_id = null;
                do
                {
                    RNG.Value.NextBytes(buffer);
                    session_id = Convert.ToBase64String(buffer);
                }
                while (SESSIONS.ContainsKey(session_id));
                SESSIONS[session_id] = s = new S() { LastAccessed = DateTime.UtcNow };
                cookie = new HttpCookie("SESSION_ID", session_id);
            }

            if (cookie != null)
            {
                e.Response.Cookies.Add(cookie);
                return s;
            }
            return null;
        }

        public static bool IsAuthenticated(HttpRequestEventArgs e)
        {
            S s = GetSession(e);
            return s.Get<bool>("Authenticated");
        }

        public static void Authenticate(HttpRequestEventArgs e, Action<HttpRequestEventArgs> on_success, Action<HttpRequestEventArgs> on_failure)
        {
            S s = GetSession(e);
            if (s.Get<bool>("Authenticated"))
            {
                on_success(e);
                return;
            }
            else
            {
                string email = (e.Request.Form["email"] ?? string.Empty).Trim();
                string pass = (e.Request.Form["password"] ?? string.Empty).Trim().Hash();
                foreach (var user in Db.Users)
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals(email, user.Email))
                    {
                        if (StringComparer.Ordinal.Equals(pass, user.PasswordHash))
                        {
                            s.Values["Authenticated"] = true;
                            on_success(e);
                            return;

                        }
                    }
                }
            }

            on_failure(e);
        }

        public static T Get<T>(HttpRequestEventArgs e, string key)
        {
            S s = GetSession(e);
            return s.Get<T>(key);
        }

        public static void Put(HttpRequestEventArgs e, string key, object value)
        {
            S s = GetSession(e);
            s.Values[key] = value;
        }
    }
}
