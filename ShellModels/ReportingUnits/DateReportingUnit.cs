using System;

namespace ShellModels.ReportingUnits
{
    public class DateReportingUnit
    {
        DateTime DateRecorded { get; set; }
        decimal ValueMinimum { get; set; }
        decimal ValueMedian { get; set; }
        decimal ValueMaximum { get; set; }
    }
}
