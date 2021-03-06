using System.Linq;
using System.Collections.Generic;
using LinqStatistics;
using ShellApiRepository.Interfaces;
using ShellApiService.Interfaces;
using ShellModels.RawData;
using ShellModels;


namespace ShellApiService.Implementation
{
    /// <summary>
    /// Loads data and returns a list of *ReportingUnits
    /// depending upon request type
    /// </summary>
    public class SanitizedEnergyRecordsService : ISanitizedEnergyRecordsService
    {
        private readonly IDataLoaderGeneric dataLoader;

        public SanitizedEnergyRecordsService(IDataLoaderGeneric dataLoader)
        {
            this.dataLoader = dataLoader;
        }

        /// <summary>
        /// Get min/max/median grouped by meter, date and datatype
        /// </summary>
        /// <returns></returns>
        IList<ReportingUnit> ISanitizedEnergyRecordsService.GetSanitizedData()
        {
            IEnumerable<ReportingFields> data = GetMergedData();

            // Distribute the data via an API based on Date (no time), Meter and Data Type
            var results = new List<ReportingUnit>();

            // get distinct by meter, reporting date and data type
            var distinct = data.Select(d => new { d.Meter, d.RecordDateString, d.EnergyDataType }).Distinct().ToList();

            // get min,max & median 
            foreach (var item in distinct)
            {
                // get set by Date (no time), Meter & DataTypr
                var set = data.Where(d => d.Meter == item.Meter &&
                d.RecordDateString == item.RecordDateString &&
                d.EnergyDataType == item.EnergyDataType);

                // get set calculations
                var min = set.Min(d => d.EnergyDataValue);
                var max = set.Max(d => d.EnergyDataValue);
                var median = set.Select(d => d.EnergyDataValue).Median();

                // create data point for reporting
                var reportingUnit = new ReportingUnit(item.Meter, item.RecordDateString, item.EnergyDataType, min, median, max);

                results.Add(reportingUnit);
            }

            return results;
            
        }

        /// <summary>
        /// Get min/max/median grouped by meter
        /// </summary>
        /// <returns></returns>
        IList<ReportingUnit> ISanitizedEnergyRecordsService.GetDataByMeter()
        {
            IEnumerable<ReportingFields> data = GetMergedData();

            var results = new List<ReportingUnit>();

            // get distinct by meter, reporting date and data type
            var distinct = data.Select(d => new { d.Meter }).Distinct().ToList();

            // get min,max & median 
            foreach (var item in distinct)
            {
                // get set by Meter
                var set = data.Where(d => d.Meter == item.Meter);

                // get set calculations
                var min = set.Min(d => d.EnergyDataValue);
                var max = set.Max(d => d.EnergyDataValue);
                var median = set.Select(d => d.EnergyDataValue).Median();

                // create data point for reporting
                var reportingUnit = new ReportingUnit(item.Meter, null, null, min, median, max);

                results.Add(reportingUnit);
            }

            return results;
        }

        /// <summary>
        /// Get min/max/median grouped by EnergyDataType
        /// </summary>
        /// <returns></returns>
        IList<ReportingUnit> ISanitizedEnergyRecordsService.GetDataByDataType()
        {
            IEnumerable<ReportingFields> data = GetMergedData();

            var results = new List<ReportingUnit>();

            // get distinct by meter, reporting date and data type
            var distinct = data.Select(d => new { d.EnergyDataType }).Distinct().ToList();

            // get min,max & median 
            foreach (var item in distinct)
            {
                // get set by EnergyDataType
                var set = data.Where(d => d.EnergyDataType == item.EnergyDataType);

                // get set calculations
                var min = set.Min(d => d.EnergyDataValue);
                var max = set.Max(d => d.EnergyDataValue);
                var median = set.Select(d => d.EnergyDataValue).Median();

                // create data point for reporting
                var reportingUnit = new ReportingUnit(null, null, item.EnergyDataType, min, median, max);

                results.Add(reportingUnit);
            }

            return results;
        }


        /// <summary>
        /// Get min/max/median grouped by Date
        /// </summary>
        /// <returns></returns>
        IList<ReportingUnit> ISanitizedEnergyRecordsService.GetDataByDate()
        {
            IEnumerable<ReportingFields> data = GetMergedData();

            var results = new List<ReportingUnit>();

            // get distinct by reporting date
            var distinct = data.Select(d => new { d.RecordDateString }).Distinct().ToList();

            // get min,max & median 
            foreach (var item in distinct)
            {
                // get set by Date
                var set = data.Where(d => d.RecordDateString == item.RecordDateString);

                // get set calculations
                var min = set.Min(d => d.EnergyDataValue);
                var max = set.Max(d => d.EnergyDataValue);
                var median = set.Select(d => d.EnergyDataValue).Median();

                // create data point for reporting
                var reportingUnit = new ReportingUnit(null, item.RecordDateString, null, min, median, max);

                results.Add(reportingUnit);
            }

            return results;
        }


        /// <summary>
        /// Processes the loaded files, extracts the relevant fields, and merges data from both sets.
        /// </summary>
        /// <returns>List of rows</returns>
        private IEnumerable<ReportingFields> GetMergedData()
        {
            var lpData = dataLoader.LoadData<LpRow, LpRowMap>("LP");
            var touData = dataLoader.LoadData<TouRow, TouRowMap>("TOU");

            // union data and select subset
            var lpSubset = lpData.Select(r => new ReportingFields
            {
                RecordDateString = r.RecordDateTime.Date.ToString("yyyyMMdd"),
                Meter = r.Meter,
                EnergyDataType = r.EnergyDataType,
                EnergyDataValue = r.EnergyDataValue
            });

            var touSubset = touData.Select(r => new ReportingFields
            {
                RecordDateString = r.RecordDateTime.Date.ToString("yyyyMMdd"),
                Meter = r.Meter,
                EnergyDataType = r.EnergyDataType,
                EnergyDataValue = r.EnergyDataValue
            });

            // merge sets
            var unionedSets = lpSubset.Union(touSubset);
            return unionedSets;
        }

    }
}
