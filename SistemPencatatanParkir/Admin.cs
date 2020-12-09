using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class Admin: User
    {
        protected bool is_active;

        public bool Is_active { get => is_active; set => is_active = value; }

        public Admin(string username, string password)
        {
            Username = "admin";
            Password = "12345678";

            if (username == Username && password == Password){
                Is_active = true;
            }
            else
            {
                Is_active = false;
            }

        }
    }
}
