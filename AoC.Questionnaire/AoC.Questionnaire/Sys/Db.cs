using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STSdb4.Database;
using AoC.Questionnaire.Model;

namespace AoC.Questionnaire
{
    public static class Db
    {
        private static IStorageEngine _engine;

        public static void Initialize()
        {
            _engine = STSdb.FromFile(Config.Db);
            var regions = _engine.OpenXTable<int, AOCRegion>("regions");
            var organisations = _engine.OpenXTable<int, AOCOrganisation>("organisations");
            var users = _engine.OpenXTable<string, AOCUser>("users");

            foreach (var o in Config.Organisations)
            {
                AOCOrganisation org = new AOCOrganisation()
                {
                    ID = StringComparer.OrdinalIgnoreCase.GetHashCode(o),
                    Name = o
                };
                organisations[org.ID] = org;
            }
            Console.WriteLine("Added {0} organisations", organisations.Count());

            foreach (var r in Config.Regions)
            {
                AOCRegion reg = new AOCRegion()
                {
                    ID = StringComparer.OrdinalIgnoreCase.GetHashCode(r),
                    Name = r
                };
                regions[reg.ID] = reg;
            }
            Console.WriteLine("Added {0} regions", regions.Count());

            foreach (var u in Config.Users)
            {
                users[u.Email] = u;
            }
            Console.WriteLine("Added {0} users", users.Count());

#if DEBUG
            var entries = _engine.OpenXTable<string, AOCEntry>("entries");
            var names = new Dictionary<string, string>()
            {
                { "Julian", "Vallis"},
                { "Tim", "Peet" },
                { "Emma", "Baines" },
                { "Rachel", "Gaskell" },
                { "Karen", "Porter" },
                { "Matt", "Cridland" },
                { "Ross", "Hopcraft" },
                { "Helene", "Dickson" },
                { "April", "Felker" },
                { "Fiona", "Vallis" },
                { "Sandra", "Lim" },
                { "Bilbo", "Baggins" },
                { "Jeremy", "Paxman" },
                { "Freddie", "Mercury" },
                { "Mick", "Jagger" },
                { "Keith", "Richards" },
                { "Bill", "Wyman" },
                { "Charlie", "Watts" },
                { "Carlos", "Santana" },
                { "Paul", "McCartney" },
                { "John", "Lennon" },
                { "James", "Bond" },
                { "Sean", "Connery" },
                { "George", "Lazenby" },
                { "Roger", "Moore" },
                { "Timothy", "Dalton" },
                { "Pierce", "Brosnan" },
                { "Daniel", "Craig" },
            };

            foreach (var name in names)
            {
                entries[name.Key.ToLowerInvariant() + "@bisqit.co.uk"] = new AOCEntry()
                {
                    Answers = "1,2,3,4,1,2,3,4",
                    Available = true,
                    Email = name.Key.ToLowerInvariant() + "@bisqit.co.uk",
                    FirstName = name.Key,
                    LastName = name.Value,
                    LineManager = "God",
                    Organisation = "Bisqit",
                    Reason = "Because...",
                    Region = "London",
                    Role = "God",
                    Score = 10,
                    Submitted = DateTime.UtcNow
                };
            }
#endif


            _engine.Commit();
        }

        public static IDictionary<int, AOCRegion> Regions
        {
            get
            {
                if (_engine == null)
                    Initialize();
                return _engine.OpenXTable<int, AOCRegion>("regions").ToDictionary(p => p.Key, p => p.Value);
            }
        }

        public static IDictionary<int, AOCOrganisation> Organisations
        {
            get
            {
                if (_engine == null)
                    Initialize();
                return _engine.OpenXTable<int, AOCOrganisation>("organisations").ToDictionary(p => p.Key, p => p.Value);
            }
        }

        public static ICollection<AOCEntry> Entries
        {
            get
            {
                if (_engine == null)
                    Initialize();
                return _engine.OpenXTable<string, AOCEntry>("entries").Select(p => p.Value).ToList();
            }
        }

        public static ICollection<AOCUser> Users
        {
            get
            {
                if (_engine == null)
                    Initialize();
                return _engine.OpenXTable<string, AOCUser>("users").Select(p => p.Value).ToList();
            }
        }

        public static void AddEntry(AOCEntry entry)
        {
            if (_engine == null)
                Initialize();

            var table = _engine.OpenXTable<string, AOCEntry>("entries");

            table[entry.Email] = entry;
            _engine.Commit();
        }
    }
}
