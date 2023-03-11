public interface IPersonaServices_S
    {
        Task<ServiceResponse<List<Personas>>> GetList();
        Task<ServiceResponse<Personas>> Buscar(int Id);
        Task<ServiceResponse<Personas>> Insertar(Personas persona);
        Task<ServiceResponse<Personas>> Modificar(Personas persona);
        Task<ServiceResponse<Personas>> Eliminar(int Id);
       
    }