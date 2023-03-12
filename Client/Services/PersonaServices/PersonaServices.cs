using System.Net.Http.Json;

public class PersonaServices : IPersonaServices
    {
        
        private readonly HttpClient _http;

        public PersonaServices(HttpClient http)
        {
            _http = http;
        }

    public List<Personas> ListaPersonas { get ; set ; } = new List<Personas>();

    public async Task<Personas> Buscar(int Id)
        {
            var result= await _http.GetFromJsonAsync<ServiceResponse<Personas>>($"api/Personas/{Id}");
                
            return result.Data;

        }

        public async Task<ServiceResponse<string>> Eliminar(int Id)
        {
            var response = await _http.DeleteAsync($"api/Personas/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string> { Success = true, Data = result };
        }

        public async Task GetList()
        {
           var results = await _http.GetFromJsonAsync<ServiceResponse<List<Personas>>>("api/Personas");

            if (results != null && results.Data != null)
            {
                ListaPersonas = results.Data;
            }
        }

        public async Task<ServiceResponse<Personas>> Guardar(Personas personas)
        {
            try
            {
                if (personas.PersonaId == 0)
                {
                    // La persona no existe, insertarla en la base de datos
                    var response = await _http.PostAsJsonAsync("api/Personas", personas);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<Personas>();
                    return new ServiceResponse<Personas> { Success = true, Data = result };
                }
                else
                {
                    // La persona existe, modificarla en la base de datos
                    var response = await _http.PutAsJsonAsync($"api/Personas/{personas.PersonaId}", personas);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<Personas>();
                    return new ServiceResponse<Personas> { Success = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Personas> { Success = false, Message = ex.Message };
            }
        }
    }