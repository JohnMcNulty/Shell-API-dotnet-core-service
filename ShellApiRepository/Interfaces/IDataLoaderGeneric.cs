using System.Collections.Generic;
using CsvHelper.Configuration;

namespace ShellApiRepository.Interfaces
{
    public interface IDataLoaderGeneric
    {
        IList<T> LoadData<T, TMap>(string fileNamePrefix)
            where T : class
            where TMap : ClassMap<T>;
    }
}
