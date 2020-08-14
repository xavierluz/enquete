using app_enquete.Domain;
using app_enquete.Repositories;
using app_enquete.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : BaseController
    {
        private IRepositorio<Vote> repositorio = null;
        private VoteServices voteServices = null;
        public VoteController()
        {
            this.unitOfWork = UnitOfWork.GetInstanceLazyLoad(base.contexto);
            this.repositorio = base.unitOfWork.VoteRepositorio;
            this.voteServices = new VoteServices(this.repositorio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vote vote)
        {
            try
            {
                var retorno = await this.voteServices.Create(vote);
                if (retorno != null)
                    return Ok(retorno);

                return Ok("Erro ao salvar o voto");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("{pollId:int}/vote")]  // GET /api/v/1
        public async Task<IActionResult> Get(int pollId)
        {
            try
            {
                var retorno = await this.voteServices.Get(pollId);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
