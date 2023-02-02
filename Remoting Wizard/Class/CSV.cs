using CsvHelper;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Remoting_Wizard.Class
{
    public static class CSV
    {
        private static readonly string _FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard\PCs.csv";

        public static List<PC> ReadCSV()
        {
            if (!Directory.Exists(Path.GetDirectoryName(_FilePath)))
            {
                return new();
            }

            if (!File.Exists(_FilePath))
            {
                return new();
            }

            List<PC> Pcs = new();
            using (var reader = new StreamReader(_FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Pcs = csv.GetRecords<PC>().ToList();
            }

            return Pcs;
        }


        public static void ExportCsv(List<PC> PCSaveConfig)
        {
            if (!Directory.Exists(Path.GetDirectoryName(_FilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_FilePath));
            }


            // Write to a file.
            using (var writer = new StreamWriter(_FilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(PCSaveConfig);
            }
        }
    }
}
