using System;
namespace ShellModels.RawData
{
    /// <summary>
    /// Encapsulates a row from a 'TOU_...csv' file
    /// </summary>
    public class TouRow
    {
        public TouRow(string meterCode, string serial, string plantCode, DateTime recordDate,
            string quality, string recordStream, string energyDataType, decimal energy, string units)
        {
            MeterCode = meterCode;
            Serial = serial;
            PlantCode = plantCode;
            RecordDate = recordDate;
            Quality = quality;
            RecordStream = recordStream;
            EnergyDataType = energyDataType;
            Energy = energy;
            Units = units;
        }

        public string MeterCode { get; }
        public string Serial { get; }
        public string PlantCode { get; }
        public DateTime RecordDate { get; }
        public string Quality { get; }
        public string RecordStream { get; }
        public string EnergyDataType { get; }
        public decimal Energy { get; }
        public string Units { get; }
    }
}
