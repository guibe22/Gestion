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
                if(_context.Aportes!=null){
                    _context.Aportes.Add(aporte);
                }
                if(_context.Personas!=null){
                     var persona= _context.Personas.Find(aporte.PersonaId);
                     if(persona!=null)
                        persona.TotalAportado+=aporte.Monto;
                        _context.Entry(persona).State = EntityState.Modified;
                }
                if(_context.TiposAportes!=null){
                    foreach (var item in aporte.DetalleAporte)
                    {
                        var tipo = _context.TiposAportes.Find(item.TipoAporteId);
                        if(tipo!=null)
                            tipo.Logrado+= item.Valor;
                        _context.Entry(tipo).State = EntityState.Modified;
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


    public async Task<ServiceResponse<Aportes>> Modificar(Aportes aporte)
    {
         var response = new ServiceResponse<Aportes>();
            try
            {
                if(_context.Personas!=null && _context.Aportes!=null && _context.AporteDetalles!=null && _context.TiposAportes!=null){
                    var AporteAnterior = _context.Aportes
                    .Where(a => a.AporteId == aporte.AporteId)
                    .Include(p =>  p.DetalleAporte)
                    .AsNoTracking()
                    .SingleOrDefault();

                    var persona= _context.Personas.Find(aporte.AporteId);
                    if(persona!=null && AporteAnterior!=null){
                        persona.TotalAportado-=AporteAnterior.Monto;
                        persona.TotalAportado+= aporte.Monto;
                        _context.Entry(persona).State = EntityState.Modified;
                        _context.AporteDetalles.RemoveRange(AporteAnterior.DetalleAporte);

                          foreach (var detalle in AporteAnterior.DetalleAporte)
                        {
                           var TipoAporte =  _context.TiposAportes.Find(detalle.TipoAporteId);
                           if(TipoAporte!=null){
                            TipoAporte.Logrado-= detalle.Valor;
                            _context.Entry(TipoAporte).State = EntityState.Modified;
                           }
                            
                        }

                         foreach (var detalle in aporte.DetalleAporte)
                        {
                           var TipoAporte =  _context.TiposAportes.Find(detalle.TipoAporteId);
                           if(TipoAporte!=null){
                            TipoAporte.Logrado+= detalle.Valor;
                            _context.Entry(TipoAporte).State = EntityState.Modified;
                           }
                            
                        }
                    }

                  
                }
                
                _context.Entry(aporte).State = EntityState.Modified;
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
    public async Task<ServiceResponse<Aportes>> Buscar(int Id)
    {
        var response = new ServiceResponse<Aportes>();
            
            if(_context.Aportes!=null){
                var aporte = await _context.Aportes.FindAsync(Id);
            

            
                if (aporte == null)
                {
                    response.Success = false;
                    response.Message = "esta persona no existe";
                }
                else
                {
                    response.Data = aporte;
                }
            }
            return response;
    }
    public async Task<ServiceResponse<Aportes>> Eliminar(int Id)
    {
        var response = new ServiceResponse<Aportes>();
            try
            {    if(_context.Aportes!=null && _context.AporteDetalles!=null && _context.TiposAportes !=null && _context.Personas!=null ){
                    var aporte = await _context.Aportes.FindAsync(Id);
                    

                    if (aporte != null)
                    {
                        foreach (var detalle in aporte.DetalleAporte)
                        {
                           var TipoAporte =  _context.TiposAportes.Find(detalle.TipoAporteId);
                           if(TipoAporte!=null){
                            TipoAporte.Logrado-= detalle.Valor;
                            _context.Entry(TipoAporte).State = EntityState.Modified;
                           }
                            
                        }
                        var persona= _context.Personas.Find(aporte.PersonaId);
                        if(persona!=null){
                            persona.TotalAportado-= aporte.Monto;
                        }
                        _context.Aportes.Remove(aporte);
                        await _context.SaveChangesAsync();
                        response.Data = aporte;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "El Aporte no existe.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response; ;
    }

    public async Task<ServiceResponse<List<Aportes>>> GetList()
    {
        var response= new ServiceResponse<List<Aportes>>();
            if(_context.Aportes!=null){
           response = new ServiceResponse<List<Aportes>>()
            {
                
                Data = await _context.Aportes.ToListAsync()
            };
            }
            return response;
    }

    
}