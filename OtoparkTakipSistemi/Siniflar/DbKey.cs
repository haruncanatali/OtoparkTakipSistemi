using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Siniflar
{
    public class DbKey
    {
        public static string GirisPath = null;
        public static string CikisPath = null;
        public static string DbFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\OtoparkDb\\OtoparkDb.txt";
        public static string DbDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\OtoparkDb";
    }
}
