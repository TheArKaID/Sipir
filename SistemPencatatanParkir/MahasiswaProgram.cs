using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SistemPencatatanParkir
{
    class MahasiswaProgram
    {
        protected List<Mahasiswa> allMahasiswa;
        protected List<Kendaraan> allkendaraan;

        private Mahasiswa myData;
        private bool isLoggedIn = false;

        public List<Mahasiswa> AllMahasiswa { get => allMahasiswa; set => allMahasiswa = value; }
        public List<Kendaraan> Allkendaraan { get => allkendaraan; set => allkendaraan = value; }

        public MahasiswaProgram(List<Mahasiswa> mahasiswas, List<Kendaraan> kendaraans)
        {
            AllMahasiswa = mahasiswas;
            Allkendaraan = kendaraans;

            Console.Write("Username = ");
            string username = Console.ReadLine();
            Console.Write("Password = ");
            string password = Console.ReadLine();

            foreach (Mahasiswa mahasiswa in AllMahasiswa)
            {
                if (username == mahasiswa.Username && password == mahasiswa.Password)
                {
                    isLoggedIn = true;
                    myData = mahasiswa;
                    AllMahasiswa.Remove(mahasiswa);

                    Console.Clear();
                    break;
                }
            }
        }

        public void program()
        {
            if (!isLoggedIn)
            {
                Console.WriteLine("Maaf, Username atau Password anda salah.\nEnter to Exit.");
                Console.ReadLine();
                return;
            }

            bool again2 = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistem Pencatan Parkir.\nAplikasi ini mencatat data Mahasiswa, Kendaraan dan Histori keluar masuknya.");
                Console.WriteLine("1. My Data\n2. Ubah Data\n3. Kendaraan\n4. Parkir\n0. Keluar");

                if (!int.TryParse(Console.ReadLine(), out int key2))
                {
                    Console.Clear();
                    continue;
                }

                if (key2 == 1)
                {
                    Console.WriteLine("Nama         = " + myData.Nama);
                    Console.WriteLine("NIM          = " + myData.Nim);
                    Console.WriteLine("Username     = " + myData.Username);
                    Console.ReadLine();
                }
                else if (key2 == 2)
                {
                    // Ubah Data
                    Console.WriteLine("Nama         = ");
                    myData.Nama = Console.ReadLine();
                    Console.WriteLine("NIM          = ");
                    myData.Nim = Console.ReadLine();
                    Console.WriteLine("Username     = ");
                    myData.Username = Console.ReadLine();
                    Console.WriteLine("Data Tersimpan");
                    Console.ReadLine();
                }
                else if (key2 == 3)
                {
                    // Kendaraan
                    KendaraanProgram kendaraanProgram = new KendaraanProgram(myData.Kendaraan);
                    kendaraanProgram.program();
                    myData.Kendaraan = kendaraanProgram.Kendaraan;
                }
                else if (key2 == 4)
                {
                    // Parkir
                    Parkiran();
                }
                else if (key2 == 0)
                {
                    again2 = false;
                }
                else
                {
                    Console.WriteLine("Tidak ada pilihan lain.");
                }

            } while (again2);

            AllMahasiswa.Add(myData);
            Console.WriteLine("Closing from Mahasiswa...");
            Thread.Sleep(1500);
        }

        private void Parkiran()
        {
            if (myData.Kendaraan == null)
            {
                Console.WriteLine("Maaf, anda tidak memiliki Kendaraan. Tidak bisa Parkir");
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
                    Console.WriteLine("Selamat Data di Parkiran.");
                    Console.WriteLine("1. Masuk Parkiran\n2. Keluar Parkiran\n0. Kembali");

                    if (!int.TryParse(Console.ReadLine(), out int key4))
                    {
                        continue;
                    }

                    if (key4 == 1)
                    {
                        isParkir = true;
                        now = DateTime.Now.TimeOfDay;

                        Console.WriteLine("Motor Diparkirkan!");
                        Console.ReadLine();
                    }
                    else if (key4 == 2)
                    {
                        if (isParkir)
                        {
                            isParkir = false;
                            Console.WriteLine("Anda parkir selama " + (DateTime.Now.TimeOfDay - now));
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Anda tidak sedang Parkir");
                            Console.ReadLine();
                        }
                    }
                    else if (key4 == 0)
                    {
                        if (isParkir)
                        {
                            Console.WriteLine("Maaf, Anda sedang Parkir, Silahkan keluar parkiran terlebih dahulu");
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
