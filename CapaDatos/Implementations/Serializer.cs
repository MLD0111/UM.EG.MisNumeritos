using CapaDatos.Interfaces;
using Newtonsoft.Json;

namespace CapaDatos.Implementations
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
