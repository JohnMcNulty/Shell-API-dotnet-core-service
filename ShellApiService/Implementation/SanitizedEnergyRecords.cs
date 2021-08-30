using System;
using System.Collections.Generic;
using ShellApiRepository.Interfaces;
using ShellApiService.Interfaces;
using ShellModels.ReportingUnits;

namespace ShellApiService.Implementation
{
    public class SanitizedEnergyRecordsService : ISanitizedEnergyRecordsService
    {
        private readonly IDataLoader dataLoader;

        public SanitizedEnergyRecordsService(IDataLoader dataLoader)
        {
            this.dataLoader = dataLoader;
            // should keep a singleton reference to the data here.
            // refresh if null


        }

        IList<DateReportingUnit> ISanitizedEnergyRecordsService.GetDataByDate()
        {
            throw new NotImplementedException();
        }

        IList<EnergyDataTypeReportingUnit> ISanitizedEnergyRecordsService.GetDataByEnergyDataType()
        {
            throw new NotImplementedException();
        }

        IList<MeterReportingUnit> ISanitizedEnergyRecordsService.GetDataByMeter()
        {
            var lpData = dataLoader.LoadLpData();
            var touData = dataLoader.LoadTouData();


            

            throw new NotImplementedException();
        }
    }
}
