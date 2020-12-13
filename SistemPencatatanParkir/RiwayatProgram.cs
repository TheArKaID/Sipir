using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class RiwayatProgram
    {
        protected Kendaraan kendaraan;
        public Kendaraan Kendaraan { get => kendaraan; set => kendaraan = value; }

        public RiwayatProgram(Kendaraan kendaraan)
        {
            Kendaraan = kendaraan;
        }

        public void program()
        {
            if (Kendaraan == null)
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("- Maaf, anda tidak memiliki Kendaraan. Tidak bisa Parkir -");
                Console.WriteLine("==========================================================");
                Console.ReadLine();
            }
            else
            {
                bool again4 = true;
                bool isParkir = false;
                TimeSpan now = DateTime.Now.TimeOfDay;
                do
                {
                    Console.Clear();
                    Console.WriteLine("============================");
                    Console.WriteLine("- Selamat Data di Parkiran -");
                    Console.WriteLine("============================");
                    Console.WriteLine("Pilih Menu -");
                    Console.WriteLine("1. Masuk Parkiran\n" +
                                      "2. Keluar Parkiran\n" +
                                      "0. Kembali");
                    Console.WriteLine("============================");
                    Console.Write("# ");

                    if (!int.TryParse(Console.ReadLine(), out int key4))
                    {
                        continue;
                    }

                    if (key4 == 1)
                    {
                        if (isParkir)
                        {
                            Console.WriteLine("~ Anda sudah parkir ~");
                            Console.ReadLine();
                        } else
                        {
                            isParkir = true;
                            now = DateTime.Now.TimeOfDay;
                            History history = new History
                            {
                                Id = new Random().Next(1000, 9999),
                                Tipe = "Masuk",
                                Waktu = now
                            };
                            Kendaraan.Histories.Add(history);
                            Console.WriteLine("~ Motor Diparkirkan! ~");
                            Console.ReadLine();
                        }
                    }
                    else if (key4 == 2)
                    {
                        if (isParkir)
                        {
                            isParkir = false;
                            TimeSpan keluar = DateTime.Now.TimeOfDay;
                            History history = new History
                            {
                                Id = new Random().Next(1000, 9999),
                                Tipe = "Keluar",
                                Waktu = keluar
                            };
                            Kendaraan.Histories.Add(history);
                            Console.WriteLine("~ Anda parkir selama " + (keluar - now) + " ~");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("~ Anda tidak sedang Parkir ~");
                            Console.ReadLine();
                        }
                    }
                    else if (key4 == 0)
                    {
                        if (isParkir)
                        {
                            Console.WriteLine("~ Maaf, Anda sedang Parkir, Silahkan keluar parkiran terlebih dahulu ~");
                            Console.ReadLine();
                        }
                        else
                        {
                            again4 = false;
                        }
                    }

                } while (again4);
            }
        }
    }
}
