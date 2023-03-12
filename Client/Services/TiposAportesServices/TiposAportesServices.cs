using System.Net.Http.Json;

public class TiposAportesServices : ITiposAportesServices
{

    private readonly HttpClient _http;
    public List<TiposAportes> ListaTiposAportes{ get; set;} = new List<TiposAportes>();

        public TiposAportesServices(HttpClient http)
        {
            _http = http;
        }
     

    public async Task GetList()
    {
         var results = await _http.GetFromJsonAsync<ServiceResponse<List<TiposAportes>>>("api/TiposAportes");

         if (results != null && results.Data != null)
            {
                ListaTiposAportes = results.Data;
            }
    }
}