    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]

    public class PersonasController : ControllerBase
    {
        private readonly IPersonaServices_S _personaServices;

        public PersonasController(IPersonaServices_S personaServices)
        {
            _personaServices = personaServices;
        }

        [HttpGet("{PersonaId}")]
        public async Task<ActionResult<ServiceResponse<List<Personas>>>> Buscar(int PersonaId)
        {
            var result = await _personaServices.Buscar(PersonaId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Personas>>>> GetList()
        {
            var result = await _personaServices.GetList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Personas>>> Insertar(Personas persona)
        {
            var response = await _personaServices.Insertar(persona);
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{PersonaId}")]
        public async Task<ActionResult<ServiceResponse<Personas>>> Modificar(int PersonaId, Personas persona)
        {
            if (PersonaId != persona.PersonaId)
            {
                return BadRequest("La identificación de la persona no coincide con el identificador proporcionado.");
            }

            var response = await _personaServices.Modificar(persona);
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{PersonaId}")]
        public async Task<IActionResult> Delete(int PersonaId)
        {
            var response = await _personaServices.Eliminar(PersonaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }