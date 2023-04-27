using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Modules
{
    static class AuthStorage
    {
        static public bool IsAuth { get; set; } = false;
        static public int RoleID { get; set; }
        static public int UserID { get; set; }
        static public string Surname { get; set; }
        static public string Name { get; set; }
        static public string Patronymic { get; set; }

    }
}
