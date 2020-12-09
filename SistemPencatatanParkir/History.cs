using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class History
    {
        protected int id;
        protected string tipe;
        protected TimeSpan waktu;

        public int Id { get => id; set => id = value; }
        public string Tipe { get => tipe; set => tipe = value; }
        public TimeSpan Waktu { get => waktu; set => waktu = value; }
    }
}
