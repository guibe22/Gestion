using System.Net.Http.Json;
public interface IAporteServices
{
    List<Aportes> ListaAportes {get; set;}
    Task<Aportes> Buscar(int Id);
    Task<ServiceResponse<Aportes>> Guardar(Aportes aporte);
    Task GetList();
    Task<ServiceResponse<string>> Eliminar(int Id);

}