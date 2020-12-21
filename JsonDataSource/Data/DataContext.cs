using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonDataSource.Data
{
    public class DataContext<T> : IDataContext<T>
    {
        private readonly string dataFile;
        private readonly IList<T> data;

        public DataContext(string dataFile)
        {
            this.dataFile = dataFile;
            data = JsonConvert.DeserializeObject<IList<T>>(File.ReadAllText(dataFile));
        }

        public IQueryable<T> Get() => data.AsQueryable();

        public void Add(T model)
        {
            lock (this)
            {
                data.Add(model);
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(dataFile, json);
            }
        }
    }
}