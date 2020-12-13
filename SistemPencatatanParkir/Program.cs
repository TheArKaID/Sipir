using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SistemPencatatanParkir
{
    class Program
    {
        List<Mahasiswa> allMahasiswa = new List<Mahasiswa>();
        List<Kendaraan> allKendaraan = new List<Kendaraan>();

        static void Main(string[] args)
        {
            Program program = new Program();

            bool again = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================");
                Console.WriteLine("Sistem Pencatan Parkir\n" +
                                  "Aplikasi ini mencatat data Mahasiswa, Kendaraan dan Histori keluar masuknya.");
                Console.WriteLine("========================");
                Console.WriteLine("- Pilih Menu -");
                Console.WriteLine("1. Admin\n" +
                                  "2. Mahasiswa\n" +
                                  "0. Keluar");
                Console.WriteLine("========================");
                Console.Write("# ");

                if (!int.TryParse(Console.ReadLine(), out int key))
                {
                    Console.Clear();
                    continue;
                }

                if (key == 1)
                {
                    // Admin
                    AdminProgram adminProgram = new AdminProgram(program.allMahasiswa);
                    program.allMahasiswa = adminProgram.program();
                }
                else if (key == 2)
                {
                    // Mahasiswa Section
                    MahasiswaProgram mahasiswaProgram = new MahasiswaProgram(program.allMahasiswa, program.allKendaraan);
                    mahasiswaProgram.program();
                    program.allMahasiswa = mahasiswaProgram.AllMahasiswa;
                    program.allKendaraan = mahasiswaProgram.Allkendaraan;

                }
                else if (key == 0)
                {
                    again = false;
                }
                else
                {
                    Console.WriteLine("~ Tidak ada pilihan lain ~");
                    Console.ReadLine();
                }

            } while (again);
            Console.WriteLine("Closing app...");
            Thread.Sleep(1000);
        }
    }
}
