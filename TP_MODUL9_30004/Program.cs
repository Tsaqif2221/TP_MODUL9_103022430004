using System;
using System.Globalization;
namespace TP_MODUL9_NIM
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();
            RunApp(covidConfig);
            Console.WriteLine("\n--- Mengubah Satuan Suhu ---\n");
            covidConfig.UbahSatuan();
            RunApp(covidConfig);
        }
        static void RunApp(CovidConfig config)
        {
            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.conf.satuan_suhu}: ");
            double suhuInput = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
            int hariDemam = Convert.ToInt32(Console.ReadLine());
            bool cekSuhu = false;
            if (config.conf.satuan_suhu == "celcius")
            {
                if (suhuInput >= 36.5 && suhuInput <= 37.5) cekSuhu = true;
            }
            else if (config.conf.satuan_suhu == "fahrenheit")
            {
                if (suhuInput >= 97.7 && suhuInput <= 99.5) cekSuhu = true;
            }
            bool cekHari = hariDemam < config.conf.batas_hari_deman;

            if (cekSuhu && cekHari)
            {
                Console.WriteLine(config.conf.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.conf.pesan_ditolak);
            }
        }
    }
}