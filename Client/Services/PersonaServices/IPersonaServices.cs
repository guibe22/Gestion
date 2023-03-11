public interface IPersonaServices
    {
        Task<Personas> Buscar(int Id);
        Task<ServiceResponse<Personas>> Guardar(Personas personas);
        Task<ServiceResponse<List<Personas>>> GetList();
        Task<ServiceResponse<string>> Eliminar(int Id);

    }