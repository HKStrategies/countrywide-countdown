using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace AoC.Questionnaire
{
    public static class Config
    {
        public static IPEndPoint Endpoint
        {
            get
            {
                var ep = ConfigurationManager.AppSettings["endpoint"];
                if (!string.IsNullOrEmpty(ep))
                {
                    string[] parts = ep.Split(':');
                    if (parts.Length == 2)
                    {
                        IPAddress address;
                        int port;
                        if (IPAddress.TryParse(parts[0], out address))
                        {
                            if (int.TryParse(parts[1], out port))
                                return new IPEndPoint(address, port);
                            else
                                return new IPEndPoint(address, 9999);
                        }
                        else
                        {
                            if (int.TryParse(parts[1], out port))
                                return new IPEndPoint(IPAddress.Any, port);
                            else
                                return new IPEndPoint(IPAddress.Any, 9999);
                        }
                    }
                }

                return new IPEndPoint(IPAddress.Any, 9999);
            }
        }

        public static string SuccessRedirect
        {
            get
            {
                var redirect = ConfigurationManager.AppSettings["success_redirect"];
                if (!string.IsNullOrEmpty(redirect))
                {
                    return redirect;
                }

                return string.Empty;
            }
        }

        public static string BaseDirectory
        {
            get
            {
                var dir = ConfigurationManager.AppSettings["base_directory"];
                if (!string.IsNullOrEmpty(dir))
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    if (Directory.Exists(dir))
                        return dir;
                }

                string default_path = Path.Combine(Environment.CurrentDirectory, "html");
                if (!Directory.Exists(default_path))
                    Directory.CreateDirectory(default_path);
                return default_path;
            }
        }

        public static string Db
        {
            get
            {
                var f = ConfigurationManager.AppSettings["db_file"];
                if (!string.IsNullOrEmpty(f))
                {
                    return Path.GetFullPath(f);
                }

                string default_path = Path.Combine(Environment.CurrentDirectory, "db");
                if (!Directory.Exists(default_path))
                    Directory.CreateDirectory(default_path);

                return Path.Combine(default_path, "AoC.db");
            }
        }

        public static ICollection<string> Regions
        {
            get
            {
                var regions = ConfigurationManager.AppSettings["regions"];
                HashSet<string> result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (!string.IsNullOrEmpty(regions))
                {
                    Console.WriteLine("Attempting to read {0}", regions);
                    if (File.Exists(regions))
                    {
                        using (var f = File.OpenRead(regions))
                        using (var sr = new StreamReader(f))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (!string.IsNullOrEmpty(line.Trim()) && !result.Contains(line))
                                    result.Add(line);
                            }
                        }
                    }
                }
                return result;
            }
        }

        public static ICollection<string> Organisations
        {
            get
            {
                var organisations = ConfigurationManager.AppSettings["organisations"];
                HashSet<string> result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (!string.IsNullOrEmpty(organisations))
                {
                    Console.WriteLine("Attempting to read {0}", organisations);
                    if (File.Exists(organisations))
                    {
                        using (var f = File.OpenRead(organisations))
                        using (var sr = new StreamReader(f))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (!string.IsNullOrEmpty(line.Trim()) && !result.Contains(line))
                                    result.Add(line);
                            }
                        }
                    }
                }
                return result;
            }
        }

        public static ICollection<Model.AOCUser> Users
        {
            get
            {
                var users = ConfigurationManager.AppSettings["users"];
                Dictionary<string, Model.AOCUser> result = new Dictionary<string, Model.AOCUser>(StringComparer.OrdinalIgnoreCase);
                if (!string.IsNullOrEmpty(users))
                {
                    Console.WriteLine("Attempting to read {0}", users);
                    if (File.Exists(users))
                    {
                        using (var f = File.OpenRead(users))
                        using (var sr = new StreamReader(f))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (!string.IsNullOrEmpty(line.Trim()))
                                {
                                    string[] parts = line.Split(',', ':', '\t');
                                    string u = null, p = null, c;
                                    for (int i = 0; i < parts.Length; ++i)
                                    {
                                        c = parts[i].Trim();
                                        if (!string.IsNullOrEmpty(c))
                                        {
                                            if (u == null)
                                            {
                                                u = c;
                                                continue;
                                            }
                                            if (p == null)
                                            {
                                                p = c;
                                                break;
                                            }
                                        }
                                    }
                                    if (u != null && p != null)
                                        result.Add(u, new Model.AOCUser() { Email = u, PasswordHash = p.Hash() });
                                }
                            }
                        }
                    }
                }
                return result.Values;
            }
        }
    }
}
