using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class Mahasiswa : User
    {
        protected string nim;
        protected Kendaraan kendaraan;

        public string Nim { get => nim; set => nim = value; }
        public Kendaraan Kendaraan { get => kendaraan; set => kendaraan = value; }
    }
}
