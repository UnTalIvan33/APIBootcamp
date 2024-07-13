using Newtonsoft.Json;

namespace EjemploEntity.DTOs
{
 
        // ChuckNorrisDTO myDeserializedClass = JsonConvert.DeserializeObject<ChuckNorrisDTO>(myJsonResponse);
        public class ChuckNorrisDTO
        {
            public List<string> MyArray { get; set; }
        }


}
