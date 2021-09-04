using System;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ShellModels.RawData
{
    /// <summary>
    /// Encapsulates a row from a 'TOU_...csv' file
    /// </summary>
    public class TouRow
    {
        public string Meter { get; set; }
        public string Serial { get; set; }
        public string PlantCode { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string Quality { get; set; }
        public string RecordStream { get; set; }
        public string EnergyDataType { get; set; }
        public decimal EnergyDataValue { get; set; }
        public string Units { get; set; }
    }

    /// <summary>
    /// Helper class to map csv values to TouRow object
    /// See ClassMap: https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
    /// </summary>
    public class TouRowMap : ClassMap<TouRow>
    {
        public TouRowMap()
        {
            Map(m => m.Meter).Name("MeterCode");
            Map(m => m.Serial).Name("Serial");
            Map(m => m.PlantCode).Name("PlantCode");
            Map(m => m.RecordDateTime).Name("DateTime").TypeConverterOption.Format("dd/MM/yyyy H:mm");
            Map(m => m.Quality).Name("Quality");
            Map(m => m.RecordStream).Name("Stream"); // not using 'Stream' to avoid confusion with C# Streams
            Map(m => m.EnergyDataType).Name("DataType");
            Map(m => m.EnergyDataValue).Name("Energy");
            Map(m => m.Units).Name("Units");
        }
    }
}
