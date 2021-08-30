using System;
using ShellModels.Enums;

namespace ShellModels.ReportingUnits
{
    public class EnergyDataTypeReportingUnit
    {
        EnergyDataTypeEnum DataType { get; set; }
        decimal ValueMinimum { get; set; }
        decimal ValueMedian { get; set; }
        decimal ValueMaximum { get; set; }
    }
}
