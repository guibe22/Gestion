    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]

    public class TiposAportesController: ControllerBase
    {
        private readonly ITiposAportesServices_S _TiposAportesServices;

        public TiposAportesController(ITiposAportesServices_S TiposAportesServices)
        {
            _TiposAportesServices = TiposAportesServices;
        }

       

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TiposAportes>>>> GetList()
        {
            var result = await _TiposAportesServices.GetList();

            return Ok(result);
        }

        
    }