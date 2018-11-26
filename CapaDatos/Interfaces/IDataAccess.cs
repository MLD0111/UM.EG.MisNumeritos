using System.Collections.Generic;
using EG.MisNumeritos.Source;

namespace CapaDatos.Interfaces
{
    public interface IDataAccess
    {
        void AddScoreToTopTen(Score record);
        List<Score> GetTopTen();
    }
}
