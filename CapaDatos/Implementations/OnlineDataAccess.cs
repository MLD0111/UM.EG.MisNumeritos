using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CapaDatos.Interfaces;
using EG.MisNumeritos.Source;

namespace CapaDatos.Implementations
{
    public class OnlineDataAccess : IDataAccess
    {
        HttpClient _HttpClient;
        ISerializer _Serializer;

        public OnlineDataAccess()
        {
            _HttpClient = new HttpClient();
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _Serializer = DataAccessFactory.GetSerializerObject();
        }

        public void AddScoreToTopTen(Score record)
        {
            // Serialize body
            string jsonData = _Serializer.Serialize(record);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make call
            HttpResponseMessage response = _HttpClient.PostAsync(EndpointsContract.AddScoreToTopTenEndpoint, content).Result;

            // If successful, deserialize and return result
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al guardar o recuperar datos de la web.");
            }
        }

        public List<Score> GetTopTen()
        {
            string jsonResult = string.Empty;

            // Make call
            HttpResponseMessage response = _HttpClient.GetAsync(EndpointsContract.GetTopTenEndpoint).Result;

            // If successful, deserialize and return result
            if (response.IsSuccessStatusCode)
            {
                jsonResult = response.Content.ReadAsStringAsync().Result;
                var result = _Serializer.Deserialize<ScoreContract>(jsonResult);
                return result.Scores;
            }
            else
            {
                throw new Exception("Error al recuperar datos de la web.");
            }
        }
    }
}
