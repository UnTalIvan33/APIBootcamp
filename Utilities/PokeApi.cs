using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EjemploEntity.Utilities
{
    public class PokeApi
    {
        private ControlError log = new ControlError();

        public async Task<Respuesta> GetPokeApi(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<PokeApiDTO>(json);
                respuesta.Mensaje = "Se consumio correcto";
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
    }
}
