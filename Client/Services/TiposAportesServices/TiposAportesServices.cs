using System.Net.Http.Json;

public class TiposAportesServices : ITiposAportesServices
{

    private readonly HttpClient _http;

        public TiposAportesServices(HttpClient http)
        {
            _http = http;
        }

    public async Task<ServiceResponse<List<TiposAportes>>> GetList()
    {
        try
            {
                var result = await _http.GetFromJsonAsync<List<TiposAportes>>("api/TiposAportes");
                return new ServiceResponse<List<TiposAportes>> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<TiposAportes>> { Success = false, Message = ex.Message };
            }
    }
}