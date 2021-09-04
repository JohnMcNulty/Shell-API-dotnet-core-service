using System;
using System.Collections.Generic;
using ShellApiRepository.Interfaces;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using System.Linq;

namespace ShellApiRepository.Implementation
{
    /// <summary>
    /// This implementation loads data from flat files.
    /// In a real world application this may be used for testing and
    /// an implementation of IDataLoader would call a DB via a Stored Procedure.
    /// </summary>
    public class FlatFileDataLoaderGeneric : IDataLoaderGeneric
    {
        IList<T> IDataLoaderGeneric.LoadData<T,TMap>(string fileNamePrefix)
        {
            List<T> result = new List<T>();
            string folder = AppDomain.CurrentDomain.BaseDirectory + "assets";
            
            foreach (var file in
                    Directory.EnumerateFiles(folder, "*.csv"))
            {
                Debug.WriteLine(file);
                var fileInfo = new FileInfo(file);

                if (!fileInfo.Name.StartsWith(fileNamePrefix))
                {
                    continue;
                }

                using (var reader = new StreamReader(file))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<TMap>();
                        var records = csv.GetRecords<T>();
                        List<T> list = records.ToList();

                        Debug.WriteLine(list.Count);

                        result.AddRange(list);
                    }
                }
            }

            return result;
        }
    }
}