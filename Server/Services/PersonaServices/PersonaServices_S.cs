public class PersonaServices_S : IPersonaServices_S
    {
        private readonly Context _context;
        public PersonaServices_S(Context context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Personas>> Insertar(Personas persona)
        {
            var response = new ServiceResponse<Personas>();
            try
            {
                if(_context.Personas!=null){
                    _context.Personas.Add(persona);
                }
                    
                await _context.SaveChangesAsync();
                response.Data = persona;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Personas>> Modificar(Personas persona)
        {
            var response = new ServiceResponse<Personas>();
            try
            {
                _context.Entry(persona).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Data = persona;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<Personas>> Buscar(int Id)
        {
            var response = new ServiceResponse<Personas>();
            
            if(_context.Personas!=null){
                var persona = await _context.Personas.FindAsync(Id);
            

            
                if (persona == null)
                {
                    response.Success = false;
                    response.Message = "esta persona no existe";
                }
                else
                {
                    response.Data = persona;
                }
            }
            return response;
        }

       
        public async Task<ServiceResponse<List<Personas>>> GetList()
        {
            var response= new ServiceResponse<List<Personas>>();
            if(_context.Personas!=null){
           response = new ServiceResponse<List<Personas>>()
            {
                
                Data = await _context.Personas.ToListAsync()
            };
            }
            return response;
        }

        public async Task<ServiceResponse<Personas>> Eliminar(int Id)
        {
            var response = new ServiceResponse<Personas>();
            try
            {    if(_context.Personas!=null){
                    var Persona = await _context.Personas.FindAsync(Id);

                    if (Persona != null)
                    {
                        _context.Personas.Remove(Persona);
                        await _context.SaveChangesAsync();
                        response.Data = Persona;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "El producto no existe.";
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
    }