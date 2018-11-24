using CapaDatos.Interfaces;

namespace CapaDatos.Implementations
{
    public class DataAccessFactory
    {
        public static IDataAccess GetDataAccessObject()
        {
            return new OnlineDataAccess();
        }

        public static ISerializer GetSerializerObject()
        {
            return new Serializer();
        }
    }
}
