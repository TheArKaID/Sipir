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
                Console.WriteLine("1. Tambah Kendaraan\n2. Edit Kendaraan\n3. Kendaraan Saya\n4. Riwayat Parkir\n0. Kembali");
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
                        Console.WriteLine("Anda sudah memiliki Kendaraan.\nMenambahkan akan menghapus Kendaraan anda sebelumnya.");
                        Console.WriteLine("1. Lanjut\nLainnya. Batal");
                        if (!int.TryParse(Console.ReadLine(), out int key4))
                        {
                            Console.Clear();
                            continue;
                        }
                        if (key4 == 1)
                        {
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
                        Console.WriteLine("Anda tidak memiliki Kendaraan.\nMau menambahkan Kendaraan ?");
                        Console.WriteLine("1. Ya\nLainnya. Batal");
                        if (!int.TryParse(Console.ReadLine(), out int key4))
                        {
                            Console.Clear();
                            continue;
                        }
                        if (key4 == 1)
                        {
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
                        Console.WriteLine("Nomor " + kendaraan.Nomor);
                        Console.WriteLine("Jenis " + kendaraan.Jenis);
                        Console.WriteLine("Merks " + kendaraan.Merk);
                        Console.ReadLine();
                    }
                }
                else if (key3 == 4)
                {
                    // Riwayat
                }
                else if (key3 == 0)
                {
                    again3 = false;
                }
                else
                {
                    Console.WriteLine("Tidak ada pilihan lain.");
                }
            } while (again3);

            if (kendaraan.Id == 0)
            {
                Console.WriteLine("Anda tidak memiliki kendaraan.");
            }
        }
    }
}
