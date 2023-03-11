public interface IAporteServices_S
{
    Task<ServiceResponse<List<Aportes>>> GetList();
    Task<ServiceResponse<Aportes>> Buscar(int Id);
    Task<ServiceResponse<Aportes>> Insertar(Aportes aporte);
    Task<ServiceResponse<Aportes>> Modificar(Aportes aporte);
    Task<ServiceResponse<Aportes>> Eliminar(int Id);
}