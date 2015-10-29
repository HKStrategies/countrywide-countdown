using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Questionnaire.Model
{
    public class AOCEntry
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Role;
        public string LineManager;
        public string Organisation;
        public string Region;
        public string Reason;
        public int Score;
        public string Answers;
        public bool Available;
        public DateTime Submitted;
    }

    public class AOCOrganisation
    {
        public int ID;
        public string Name;
    }

    public class AOCRegion
    {
        public int ID;
        public string Name;
    }

    public class AOCUser
    {
        public string Email;
        public string PasswordHash;
    }
}
