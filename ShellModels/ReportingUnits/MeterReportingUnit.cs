using System;

namespace ShellModels.ReportingUnits
{
    public class MeterReportingUnit
    {
        string MeterCode { get; set; }
        decimal ValueMinimum { get; set; }
        decimal ValueMedian { get; set; }
        decimal ValueMaximum { get; set; }
    }
}
