public interface IPersonaServices
    {
        List<Personas> ListaPersonas{get; set;}
        Task<Personas> Buscar(int Id);
        Task<ServiceResponse<Personas>> Guardar(Personas personas);
        Task GetList(); 
        Task<ServiceResponse<string>> Eliminar(int Id);

    }