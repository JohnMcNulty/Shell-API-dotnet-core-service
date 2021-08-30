using System;
namespace ShellModels.RawData
{
    /// <summary>
    /// Encapsulates a row from a 'LP_...csv' file
    /// </summary>
    public class LpRow
    {
        public LpRow(string meterPointCode, string serialName, string plantCode, DateTime recordDate,
            string energyDataType, decimal energyDataValue, string units, string status)
        {
            MeterPointCode = meterPointCode;
            SerialName = serialName;
            PlantCode = plantCode;
            RecordDate = recordDate;
            EnergyDataType = energyDataType;
            EnergyDataValue = energyDataValue;
            Units = units;
            Status = status;
        }

        public string MeterPointCode { get; }
        public string SerialName { get; }
        public string PlantCode { get; }
        public DateTime RecordDate { get; }
        public string EnergyDataType { get; }
        public decimal EnergyDataValue { get; }
        public string Units { get; }
        public string Status { get; }
    }
}
