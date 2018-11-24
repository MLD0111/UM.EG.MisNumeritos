using System.Collections.Generic;
using EG.MisNumeritos.Source;

namespace CapaDatos.Interfaces
{
    public interface IDataAccess
    {
        bool AddScoreToTopTen(Score record);
        List<Score> GetTopTen();
    }
}
