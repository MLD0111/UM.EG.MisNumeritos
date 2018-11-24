namespace CapaDatos.Interfaces
{
    public interface ISerializer
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string jsonData);
    }
}
