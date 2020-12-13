using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SistemPencatatanParkir
{
    class AdminProgram
    {
        List<Mahasiswa> allMahasiswa;

        public AdminProgram(List<Mahasiswa> mahasiswas)
        {
            allMahasiswa = mahasiswas;
        }

        public List<Mahasiswa> program()
        {
            bool isLoggedIn = false;
            do
            {
                Console.Clear();
                Console.WriteLine("===============");
                Console.WriteLine("- Login Admin -");
                Console.WriteLine("===============");

                Console.Write("Masukkan Username : ");
                string username = Console.ReadLine();
                Console.Write("Masukkan Password : ");
                string password = Console.ReadLine();

                Admin admin = new Admin(username, password);
                if (admin.Is_active)
                {
                    isLoggedIn = true;
                    admin.Is_active = true;
                }
                else
                {
                    Console.WriteLine("~ Username atau Password Salah! ~");
                    Console.WriteLine("Try Again");
                    Console.ReadLine();
                }
            } while (!isLoggedIn);

            logged();

            return allMahasiswa;
        }

        public void logged()
        {
            bool again1 = true;
            do
            {
                Console.Clear();
                Console.WriteLine("=========================");
                Console.WriteLine("Sistem Pencatan Parkir.\n" +
                                  "Aplikasi ini mencatat data Mahasiswa, Kendaraan dan Histori keluar masuknya.");
                Console.WriteLine("=========================");
                Console.WriteLine("- Pilih Menu -");
                Console.WriteLine("1. Tambah Mahasiswa\n" +
                                  "2. Lihat Semua Mahasiswa\n" +
                                  "3. Hapus Mahasiswa\n" +
                                  "4. All History\n" +
                                  "0. Keluar");
                Console.WriteLine("=========================");
                Console.Write("# ");

                if (!int.TryParse(Console.ReadLine(), out int key1))
                {
                    Console.Clear();
                    continue;
                }

                if (key1 == 1)
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("- Tambahkan Data Mahasiswa Baru -");
                    Console.WriteLine("=================================");
                    Mahasiswa mahasiswa = new Mahasiswa();
                    mahasiswa.Id = new Random().Next(1000, 9999);
                    Console.Write("Masukkan Nama        = ");
                    mahasiswa.Nama = Console.ReadLine();
                    Console.Write("Masukkan NIM         = ");
                    mahasiswa.Nim = Console.ReadLine();
                    Console.Write("Masukkan Username    = ");
                    mahasiswa.Username = Console.ReadLine();
                    Console.Write("Masukkan Password    = ");
                    mahasiswa.Password = Console.ReadLine();
                    mahasiswa.Role = "mahasiswa";

                    allMahasiswa.Add(mahasiswa);
                    Console.WriteLine("~ Mahasiswa Ditambahkan ~\nEnter untuk kembali");
                    Console.ReadLine();
                }
                else if (key1 == 2)
                {
                    int num = 1;
                    Console.Clear();
                    foreach (Mahasiswa mahasiswa in allMahasiswa)
                    {
                        Console.WriteLine(num++);
                        Console.WriteLine("==============");
                        Console.WriteLine("- ID     : " + mahasiswa.Id);
                        Console.WriteLine("- Nama   : " + mahasiswa.Nama);
                        Console.WriteLine("- NIM    : " + mahasiswa.Nim);
                        Console.WriteLine("==============");
                    }
                    Console.WriteLine("Exit....");
                    Console.ReadLine();
                }
                else if (key1 == 3)
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("- Masukkan NIM Mahasiswa untuk Dihapus -");
                    Console.WriteLine("========================================");

                    string snim = Console.ReadLine();
                    int num = 0;

                    foreach (Mahasiswa mahasiswa in allMahasiswa)
                    {
                        num++;
                        if (mahasiswa.Nim==snim)
                        {
                            Console.WriteLine("Mahasiswa dengan NIM " + snim +" - " + mahasiswa.Nama + " Dihapus");
                            allMahasiswa.Remove(mahasiswa);
                            break;
                        }
                    }
                    if(num==0)
                    {
                        Console.WriteLine("Mahasiswa Tidak Ditemukan.\nHarap Periksa NIM yang anda masukkan dan coba lagi");
                    }
                    Console.ReadLine();
                        
                }
                else if (key1 == 4)
                {
                    Console.Clear();
                    int num = 0;
                    foreach (Mahasiswa mahasiswa in allMahasiswa)
                    {
                        if (mahasiswa.Kendaraan != null)
                        {
                            if (mahasiswa.Kendaraan.Histories != null)
                            {
                                foreach (History history in mahasiswa.Kendaraan.Histories)
                                {
                                    num++;
                                    Console.WriteLine("==============");
                                    Console.WriteLine(mahasiswa.Nama + " - " + mahasiswa.Nim);
                                    Console.WriteLine(history.Tipe);
                                    Console.WriteLine(history.Waktu);
                                    Console.WriteLine("==============");
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        }
                    }
                    if (num == 0)
                    {
                        Console.WriteLine("=========================================");
                        Console.WriteLine("Maaf, Tidak ada History untuk ditampilkan");
                        Console.WriteLine("=========================================");
                    }

                    Console.ReadLine();
                }
                else if (key1 == 0)
                {
                    again1 = false;
                }
                else
                {
                    Console.WriteLine("~ Tidak ada pilihan lain ~");
                }
            } while (again1);

            Console.WriteLine("Logging out from Admin...");
            Thread.Sleep(1000);
        }
    }
}
