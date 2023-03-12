    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]

    public class AportesController : ControllerBase
    {
        private readonly IAporteServices_S _aporteServices;

        public AportesController(IAporteServices_S aporteServices)
        {
            _aporteServices = aporteServices;
        }

        [HttpGet("{AporteId}")]
        public async Task<ActionResult<ServiceResponse<List<Aportes>>>> Buscar(int AporteId)
        {
            var result = await _aporteServices.Buscar(AporteId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Aportes>>>> GetList()
        {
            var result = await _aporteServices.GetList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Aportes>>> Insertar(Aportes aporte)
        {
            var response = await _aporteServices.Insertar(aporte);
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{AporteId}")]
        public async Task<ActionResult<ServiceResponse<Aportes>>> Modificar(int AporteId, Aportes aporte)
        {
            if (AporteId!= aporte.AporteId)
            {
                return BadRequest("La identificación de la persona no coincide con el identificador proporcionado.");
            }

            var response = await _aporteServices.Modificar(aporte);
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{AporteId}")]
        public async Task<IActionResult> Delete(int AporteId)
        {
            var response = await _aporteServices.Eliminar(AporteId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }