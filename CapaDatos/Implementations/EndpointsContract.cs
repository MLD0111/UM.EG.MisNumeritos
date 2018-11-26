namespace CapaDatos.Implementations
{
    public class EndpointsContract
    {
        public static string AddScoreToTopTenEndpoint { get { return "http://vz000494.ferozo.com/v2/um/electiva-gral/api/top-ten/save.php"; } }
        public static string GetTopTenEndpoint { get { return "http://vz000494.ferozo.com/v2/um/electiva-gral/api/top-ten/read.php"; } }
    }
}
