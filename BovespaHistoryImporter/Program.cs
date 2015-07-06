using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovespaHistoryImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            BovespaData.DataClasses.FlatFileDataClass a = new BovespaData.DataClasses.FlatFileDataClass();

            a.LoadFromFlatFile(@"C:\Users\Tebaldi\Downloads\History\2015-04-08\COTAHIST_A2014\COTAHIST_A2014.txt");



        }
    }
}
