using Newtonsoft.Json;

namespace WireMockDemo
{
    public class WeatherClient
    {
        private readonly String _baseurl;

        public WeatherClient(string baseurl)
        {
            _baseurl = baseurl;
        }

        // simulando Chama a API externa obter previsão do tempo
        // poderia ser uma URL real do ClimaTempo por exemplo
        public WeatherData GetWeather()
        { 
            using var httpClient = new HttpClient();
            // passa URL do serviço externo:
            var response = httpClient.GetStringAsync($"{_baseurl}/weather").Result;
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }
    }
    public class WeatherData
    {
        public string Temperature { get; set; }
        public string Condition { get; set; }
    }
}
