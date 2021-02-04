using datApp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace datApp.Services
{
    public class DataService
    {
        private readonly IMongoCollection<Data> _datas;

        private static HttpClient client = new HttpClient();

        public DataService(ITalktelecomDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _datas = database.GetCollection<Data>(settings.DataCollectionName);
        }

        public async Task atualizationList()
        {

            HttpResponseMessage response = await client.GetAsync(
                "http://dadosbr.github.io/feriados/nacionais.json");
            // response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var data = await JsonSerializer.DeserializeAsync<IEnumerable<Data>>(responseStream);
                    System.Console.WriteLine(data);
                    foreach (var dt in data)
                    {
                        Create(dt);
                    }

                }
            }
        }

        public List<Data> Get() =>
            _datas.Find(data => true).ToList();

        public Data Get(string id) =>
            _datas.Find<Data>(data => data.Id == id).FirstOrDefault();

        public Data Create(Data data)
        {
            _datas.InsertOne(data);
            return data;
        }

        public void Update(string id, Data dataIn) =>
            _datas.ReplaceOne(data => data.Id == id, dataIn);

        public void Remove(Data dataIn) =>
            _datas.DeleteOne(data => data.Id == dataIn.Id);

        public void Remove(string id) =>
            _datas.DeleteOne(data => data.Id == id);
    }
}