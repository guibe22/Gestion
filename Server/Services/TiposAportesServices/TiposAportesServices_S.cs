public class TiposAportesServices_S : ITiposAportesServices_S
{
     private readonly Context _context;

     public TiposAportesServices_S(Context context)
     {
        _context= context;
     }
    public async Task<ServiceResponse<List<TiposAportes>>> GetList()
    {
        var response = new ServiceResponse<List<TiposAportes>>();
        if(_context.TiposAportes!=null){
             response = new ServiceResponse<List<TiposAportes>>()
                {
                    Data = await _context.TiposAportes.ToListAsync()
                };
        }
        return response;
    }
}