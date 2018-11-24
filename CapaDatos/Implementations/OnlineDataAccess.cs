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

        public bool AddScoreToTopTen(Score record)
        {
            //string jsonResult = string.Empty;

            //// Serialize body
            //string jsonData = _Serializer.Serialize(record);
            //HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //// Make call
            //HttpResponseMessage response = _HttpClient.PostAsync(EndpointsContract.AddScoreToTopTenEndpoint, content).Result;

            //// If successful, deserialize and return result
            //if (response.IsSuccessStatusCode)
            //{
            //    jsonResult = response.Content.ReadAsStringAsync().Result;
            //    return _Serializer.Deserialize<bool>(jsonResult);
            //}
            //else
            //{
            //    throw new Exception("Error al guardar o recuperar datos de la web.");
            //}
            return true;
        }

        public List<Score> GetTopTen()
        {
            //string jsonResult = string.Empty;

            //// Make call
            //HttpResponseMessage response = _HttpClient.GetAsync(EndpointsContract.GetTopTenEndpoint).Result;

            //// If successful, deserialize and return result
            //if (response.IsSuccessStatusCode)
            //{
            //    jsonResult = response.Content.ReadAsStringAsync().Result;
            //    return _Serializer.Deserialize<List<Score>>(jsonResult);
            //}
            //else
            //{
            //    throw new Exception("Error al recuperar datos de la web.");
            //}
            List<Score> testList = new List<Score> {
                new Score("A", 1),
                new Score("B", 2),
                new Score("C", 3),
                new Score("D", 4),
                new Score("E", 5),
                new Score("F", 6),
                new Score("G", 7),
                new Score("H", 8),
                new Score("I", 9),
                new Score("J", 10)
            };
            return testList;
        }
    }
}
