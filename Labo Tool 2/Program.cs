using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Labo_Tool_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task GemeenteThread = Task.Factory.StartNew(() => ReadFiles.GemeenteLees(ReadFiles.FileLees(@"C:\Users\mkell\Desktop\Rapport Labo\DataRapportGemeente.csv")));
            GemeenteThread.Wait();

            Task ProvincieThread = Task.Factory.StartNew(() => ReadFiles.ProvincieLees(ReadFiles.FileLees(@"C:\Users\mkell\Desktop\Rapport Labo\DataRapportProvincie.csv")));
            ProvincieThread.Wait();

            Task StraatnaamThread = Task.Factory.StartNew(() => ReadFiles.StratenLees(ReadFiles.FileLees(@"C:\Users\mkell\Desktop\Rapport Labo\DataRapportStraten.csv")));
            StraatnaamThread.Wait();
        }
    }
}
