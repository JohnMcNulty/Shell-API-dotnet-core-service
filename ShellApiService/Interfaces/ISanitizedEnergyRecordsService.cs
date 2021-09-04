using System;
using System.Collections.Generic;
using ShellModels;

namespace ShellApiService.Interfaces
{
    public interface ISanitizedEnergyRecordsService
    {
        IList<ReportingUnit> GetSanitizedData();
    }
}
