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
                Console.Write("Masukkan Username: ");
                string username = Console.ReadLine();
                Console.Write("Masukkan Password :");
                string password = Console.ReadLine();

                Admin admin = new Admin(username, password);
                if (admin.Is_active)
                {
                    isLoggedIn = true;
                    admin.Is_active = true;
                }
                else
                {
                    Console.WriteLine("Username atau Password Salah!");
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
                Console.WriteLine("Sistem Pencatan Parkir.\nAplikasi ini mencatat data Mahasiswa, Kendaraan dan Histori keluar masuknya.");
                Console.WriteLine("1. Tambah Mahasiswa\n2. Lihat Semua Mahasiswa\n3. All History\n0. Keluar");

                if (!int.TryParse(Console.ReadLine(), out int key1))
                {
                    Console.Clear();
                    continue;
                }

                if (key1 == 1)
                {
                    Console.Clear();
                    Mahasiswa mahasiswa = new Mahasiswa();
                    mahasiswa.Id = new Random().Next(1000, 9999);
                    Console.WriteLine("Masukkan Nama        = ");
                    mahasiswa.Nama = Console.ReadLine();
                    Console.WriteLine("Masukkan NIM         = ");
                    mahasiswa.Nim = Console.ReadLine();
                    Console.WriteLine("Masukkan Username    = ");
                    mahasiswa.Username = Console.ReadLine();
                    Console.WriteLine("Masukkan Password    = ");
                    mahasiswa.Password = Console.ReadLine();
                    mahasiswa.Role = "mahasiswa";

                    allMahasiswa.Add(mahasiswa);
                    Console.WriteLine("Mahasiswa Ditambahkan.\nEnter untuk kembali.");
                    Console.ReadLine();
                }
                else if (key1 == 2)
                {
                    int num = 1;
                    Console.Clear();
                    foreach (Mahasiswa mahasiswa in allMahasiswa)
                    {
                        Console.WriteLine(num++);
                        Console.WriteLine("=========");
                        Console.WriteLine(". ID : " + mahasiswa.Id);
                        Console.WriteLine(". Nama : " + mahasiswa.Nama);
                        Console.WriteLine(". NIM : " + mahasiswa.Nim);
                    }
                    Console.WriteLine("Exit....");
                    Console.ReadLine();
                }
                else if (key1 == 3)
                {

                }
                else if (key1 == 0)
                {
                    again1 = false;
                }
                else
                {
                    Console.WriteLine("Tidak ada pilihan lain.");
                }

            } while (again1);
            Console.WriteLine("Closing from Admin...");
            Thread.Sleep(1500);
        }
    }
}
