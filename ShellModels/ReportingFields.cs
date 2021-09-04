using System;

namespace ShellModels
{
    /// <summary>
    /// Encapsulates the necessary fields to be pulled from the data source.
    /// </summary>
    public class ReportingFields
    {
        public string RecordDateString { get; set; }
        public string Meter { get; set; }
        public string EnergyDataType { get; set; }
        public decimal EnergyDataValue { get; set; }
    }
}
