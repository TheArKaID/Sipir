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
                Console.WriteLine("Sistem Pencatan Parkir.\nAplikasi ini mencatat data Mahasiswa, Kendaraan dan Histori keluar masuknya.");
                Console.WriteLine("1. Admin\n2. Mahasiswa\n0. Keluar");

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
                    Console.WriteLine("Tidak ada pilihan lain.");
                }

            } while (again);
            Console.WriteLine("Closing app...");
            Thread.Sleep(1500);
        }
    }
}
