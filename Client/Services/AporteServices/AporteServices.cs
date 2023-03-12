using System.Net.Http.Json;

public class AporteServices : IAporteServices
{

    private readonly HttpClient _http;

        public AporteServices(HttpClient http)
        {
            _http = http;
        }

    public List<Aportes> ListaAportes { get ; set ; } = new List<Aportes>();

    public async Task<Aportes> Buscar(int Id)
    {
        var result= await _http.GetFromJsonAsync<ServiceResponse<Aportes>>($"api/Aportes/{Id}");
                
            return result.Data;
    }

    public async Task<ServiceResponse<string>> Eliminar(int Id)
    {
        var response = await _http.DeleteAsync($"api/Aportes/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string> { Success = true, Data = result };
    }

     public async Task GetList()
        {
           var results = await _http.GetFromJsonAsync<ServiceResponse<List<Aportes>>>("api/Aportes");

            if (results != null && results.Data != null)
            {
                ListaAportes = results.Data;
            }
        }

    public async Task<ServiceResponse<Aportes>> Guardar(Aportes aporte)
    {
        try
        {
            if (aporte.AporteId == 0)
            {
            // La persona no existe, insertarla en la base de datos
                var response = await _http.PostAsJsonAsync("api/Aportes", aporte);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<Aportes>();
                return new ServiceResponse<Aportes> { Success = true, Data = result };
            }
            else
            {
                // La persona existe, modificarla en la base de datos
                var response = await _http.PutAsJsonAsync($"api//{aporte.AporteId}", aporte);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<Aportes>();
                return new ServiceResponse<Aportes> { Success = true, Data = result };
             }
        }
        catch (Exception ex)
        {
                return new ServiceResponse<Aportes> { Success = false, Message = ex.Message };
        }
    }
}