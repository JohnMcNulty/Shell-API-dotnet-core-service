using System;
using CsvHelper.Configuration;

namespace ShellModels.RawData
{
    /// <summary>
    /// Encapsulates a row from a 'LP_...csv' file
    /// </summary>
    public class LpRow
    {
        public string Meter { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string EnergyDataType { get; set; }
        public decimal EnergyDataValue { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// Helper class to map csv values to LpRow object
    /// See ClassMap: https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
    /// </summary>
    public class LpRowMap: ClassMap<LpRow>
    {
        public LpRowMap()
        {
            Map(m => m.Meter).Name("MeterPoint Code");
            Map(m => m.SerialNumber).Name("Serial Number");
            Map(m => m.PlantCode).Name("Plant Code");
            Map(m => m.RecordDateTime).Name("Date/Time").TypeConverterOption.Format("dd/MM/yyyy HH:mm:ss");
            Map(m => m.EnergyDataType).Name("Data Type");
            Map(m => m.EnergyDataValue).Name("Data Value");
            Map(m => m.Units).Name("Units");
            Map(m => m.Status).Name("Status");
        }
    }
}
