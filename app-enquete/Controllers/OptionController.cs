using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_enquete.Domain;
using app_enquete.Repositories;
using app_enquete.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app_enquete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : BaseController
    {
        private IRepositorio<Option> repositorio = null;
        private OptionServices optionServices = null;

        public OptionController()
        {
            this.unitOfWork = UnitOfWork.GetInstanceLazyLoad(base.contexto);
            this.repositorio = base.unitOfWork.OptionRepositorio;
            this.optionServices = new OptionServices(this.repositorio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Option option)
        {
            try
            {
                var retorno = await this.optionServices.Create(option);
                if (retorno != null)
                    return Ok(retorno);

                return Ok("Erro ao salvar o voto");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
    
}
