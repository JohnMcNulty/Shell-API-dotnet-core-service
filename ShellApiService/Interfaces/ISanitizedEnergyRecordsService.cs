using System;
using System.Collections.Generic;
using ShellModels.ReportingUnits;

namespace ShellApiService.Interfaces
{
    public interface ISanitizedEnergyRecordsService
    {
        IList<EnergyDataTypeReportingUnit> GetDataByEnergyDataType();

        IList<DateReportingUnit> GetDataByDate();

        IList<MeterReportingUnit> GetDataByMeter();
    }
}
