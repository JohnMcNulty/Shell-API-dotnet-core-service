using System;

namespace ShellModels
{
    public class ReportingUnit
    {
        public ReportingUnit(string meterCode, string recordDate, string dataType, decimal valueMinimum, decimal valueMedian, decimal valueMaximum)
        {
            MeterCode = meterCode;
            RecordDate = recordDate;
            EnergyDataType = dataType;
            ValueMinimum = valueMinimum;
            ValueMedian = valueMedian;
            ValueMaximum = valueMaximum;
        }

        public string MeterCode { get; }
        public string RecordDate { get; }
        public string EnergyDataType { get; }
        public decimal ValueMinimum { get; }
        public decimal ValueMedian { get; }
        public decimal ValueMaximum { get; }
    }
}
