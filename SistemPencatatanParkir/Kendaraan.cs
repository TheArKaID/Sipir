using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class Kendaraan
    {
        protected int id;
        protected string nomor;
        protected string jenis;
        protected string merk;
        protected List<History> histories;

        public int Id { get => id; set => id = value; }
        public string Jenis { get => jenis; set => jenis = value; }
        public string Merk { get => merk; set => merk = value; }
        public string Nomor { get => nomor; set => nomor = value; }
        public List<History> Histories { get => histories; set => histories = value; }

        public Kendaraan()
        {
            Id = 0;
            Jenis = "";
            Merk = "";
            Nomor = "";
            histories = new List<History>();
        }
    }
}
