using System;
using System.Collections.Generic;
using ShellModels.RawData;

namespace ShellApiRepository.Interfaces
{
    public interface IDataLoader
    {
        IList<LpRow> LoadLpData();

        IList<TouRow> LoadTouData();
    }
}
