using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPencatatanParkir
{
    class KendaraanProgram
    {
        protected Kendaraan kendaraan;
        public Kendaraan Kendaraan { get => kendaraan; set => kendaraan = value; }

        public KendaraanProgram(Kendaraan kendaraan)
        {
            Kendaraan = kendaraan;
        }
        
        public void program()
        {
            if (Kendaraan == null)
            {
                kendaraan = new Kendaraan();
            }

            bool again3 = true;
            do
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("- Pilih Menu -");
                Console.WriteLine("1. Tambah Kendaraan\n" +
                                  "2. Edit Kendaraan\n" +
                                  "3. Kendaraan Saya\n" +
                                  "4. Riwayat Parkir\n" +
                                  "0. Kembali");
                Console.WriteLine("========================");
                Console.Write("# ");

                if (!int.TryParse(Console.ReadLine(), out int key3))
                {
                    Console.Clear();
                    continue;
                }

                if (key3 == 1)
                {
                    // Tambah Kendaraan
                    if (kendaraan.Id != 0)
                    {
                        Console.WriteLine("==============================");
                        Console.WriteLine("Anda sudah memiliki Kendaraan.\n" +
                                          "Menambahkan akan menghapus Kendaraan anda sebelumnya.");
                        Console.WriteLine("1. Lanjut\nLainnya. Batal");
                        Console.WriteLine("==========================");
                        if (!int.TryParse(Console.ReadLine(), out int key4))
                        {
                            Console.Clear();
                            continue;
                        }
                        if (key4 == 1)
                        {
                            Console.WriteLine("====================");
                            Console.WriteLine("= Tambah Kendaraan =");
                            Console.WriteLine("====================");
                            Console.Write("Jenis Kendaraan  = ");
                            kendaraan.Jenis = Console.ReadLine();
                            Console.Write("Merk Kendaraan   = ");
                            kendaraan.Merk = Console.ReadLine();
                            Console.Write("Nomor Kendaraan  = ");
                            kendaraan.Nomor = Console.ReadLine();
                            Console.WriteLine("Data Disimpan.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine("= Tambah Kendaraan =");
                        Console.WriteLine("====================");

                        kendaraan.Id = new Random().Next(1000, 9999);
                        Console.Write("Jenis Kendaraan = ");
                        kendaraan.Jenis = Console.ReadLine();
                        Console.Write("Merk Kendaraan = ");
                        kendaraan.Merk = Console.ReadLine();
                        Console.Write("Nomor Kendaraan = ");
                        kendaraan.Nomor = Console.ReadLine();
                        Console.WriteLine("Data Disimpan.");
                        Console.ReadLine();
                    }
                }
                else if (key3 == 2)
                {
                    // Edit Kendaraan
                    if (kendaraan.Id == 0)
                    {
                        Console.WriteLine("==============================");
                        Console.WriteLine("Anda tidak memiliki Kendaraan.\n" +
                                          "Mau menambahkan Kendaraan ?");
                        Console.WriteLine("1. Ya\nLainnya. Batal");
                        Console.WriteLine("==============================");

                        if (!int.TryParse(Console.ReadLine(), out int key4))
                        {
                            Console.Clear();
                            continue;
                        }
                        if (key4 == 1)
                        {
                            Console.WriteLine("====================");
                            Console.WriteLine("= Tambah Kendaraan =");
                            Console.WriteLine("====================");

                            kendaraan.Id = new Random().Next(1000, 9999);
                            Console.Write("Jenis Kendaraan = ");
                            kendaraan.Jenis = Console.ReadLine();
                            Console.Write("Merk Kendaraan = ");
                            kendaraan.Merk = Console.ReadLine();
                            Console.Write("Nomor Kendaraan = ");
                            kendaraan.Nomor = Console.ReadLine();
                            Console.WriteLine("Data Disimpan.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine("= Edit Kendaraan =");
                        Console.WriteLine("====================");
                        Console.Write("Jenis Kendaraan = ");
                        kendaraan.Jenis = Console.ReadLine();
                        Console.Write("Merk Kendaraan = ");
                        kendaraan.Merk = Console.ReadLine();
                        Console.Write("Nomor Kendaraan = ");
                        kendaraan.Nomor = Console.ReadLine();
                        Console.WriteLine("Data Disimpan.");
                        Console.ReadLine();
                    }
                }
                else if (key3 == 3)
                {
                    // Kendaraan Saya
                    if (kendaraan.Id == 0)
                    {
                        Console.WriteLine("Anda Tidak memiliki Kendaraan. Silahkan tambahkan terlebih dahulu!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine("= Data Kendaraan =");
                        Console.WriteLine("==================");
                        Console.WriteLine("Nomor " + kendaraan.Nomor);
                        Console.WriteLine("Jenis " + kendaraan.Jenis);
                        Console.WriteLine("Merks " + kendaraan.Merk);
                        Console.WriteLine("==================");
                        Console.ReadLine();
                    }
                }
                else if (key3 == 4)
                {
                    // Riwayat
                    Console.Clear();
                    Console.WriteLine("=======================");
                    Console.WriteLine("= Riwayat Parkir anda =");
                    Console.WriteLine("=======================");

                    foreach (History history in Kendaraan.Histories)
                    {
                        Console.WriteLine("Tipe     = " + history.Tipe);
                        Console.WriteLine("Waktu    = " + history.Waktu);
                        Console.WriteLine("===================");
                    }
                    Console.ReadLine();
                }
                else if (key3 == 0)
                {
                    again3 = false;
                }
                else
                {
                    Console.WriteLine("~ Tidak ada pilihan lain ~");
                }
            } while (again3);

            if (kendaraan.Id == 0)
            {
                Console.WriteLine("Anda tidak memiliki kendaraan.");
            }
        }
    }
}
