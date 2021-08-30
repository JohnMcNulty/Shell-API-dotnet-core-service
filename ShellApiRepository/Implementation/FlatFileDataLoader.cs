using System;
using System.Collections.Generic;
using ShellApiRepository.Interfaces;
using ShellModels.RawData;
using System.IO;

namespace ShellApiRepository.Implementation
{
    public class DataLoader : IDataLoader
    {
        /// <summary>
        /// Load raw data from 'LP_...csv' flatfiles
        /// </summary>
        /// <returns>List of raw LP records</returns>
        IList<LpRow> IDataLoader.LoadLpData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load raw data from 'TOU_...csv' flatfiles
        /// </summary>
        /// <returns>List of raw TOU records</returns>
        IList<TouRow> IDataLoader.LoadTouData()
        {
            throw new NotImplementedException();
        }
    }
}
