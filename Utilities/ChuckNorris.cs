using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilities
{
    public class ChuckNorris
    {
        private ControlError log = new ControlError();

        public async Task<Respuesta> GetChuckNorris(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisDTO>(json);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorris", "GetChuckNorris", ex.Message);
            }
            return respuesta;
        }
    }
}
