public class AporteServices_S : IAporteServices_S
{
    private readonly Context _context;
    public AporteServices_S(Context context)
    {
        _context= context;
    }
    public async Task<ServiceResponse<Aportes>> Insertar(Aportes aporte)
    {
         var response = new ServiceResponse<Aportes>();
      
            try
            {
                if(_context.Personas!=null && _context.Aportes!=null){

                    _context.Aportes.Add(aporte);

                     var persona = _context.Personas.Find(aporte.PersonaId);
                     if(persona!=null){
                        persona.TotalAportado+= aporte.Monto;
                        _context.Entry(persona).State = EntityState.Modified;
                        _context.Personas.Add(persona);
                     } 
                }
                    
                await _context.SaveChangesAsync();
                response.Data = aporte;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
    }

    public Task<ServiceResponse<Aportes>> Modificar(Aportes aporte)
    {
        throw new NotImplementedException();
    }
    public Task<ServiceResponse<Aportes>> Buscar(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Aportes>> Eliminar(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Aportes>>> GetList()
    {
        throw new NotImplementedException();
    }

    
}