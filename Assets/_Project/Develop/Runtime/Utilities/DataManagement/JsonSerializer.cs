using Newtonsoft.Json;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagement
{
    public class JsonSerializer : IDataSerializer
    {
        TData IDataSerializer.Deserialize<TData>(string serializedData)
        {
            return JsonConvert.DeserializeObject<TData>(serializedData);
        }

        string IDataSerializer.Serialize<TData>(TData data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}