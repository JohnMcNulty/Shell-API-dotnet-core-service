using System;
using System.Collections.Generic;
using ShellModels;

namespace ShellApiService.Interfaces
{
    public interface ISanitizedEnergyRecordsService
    {
        IList<ReportingUnit> GetSanitizedData();

        IList<ReportingUnit> GetDataByMeter();

        IList<ReportingUnit> GetDataByDataType();

        IList<ReportingUnit> GetDataByDate();
    }
}
