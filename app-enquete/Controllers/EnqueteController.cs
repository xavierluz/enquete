 using System;
using System.Linq;
using System.Threading.Tasks;
using app_enquete.Domain;
using app_enquete.Repositories;
using app_enquete.Services;
using Microsoft.AspNetCore.Mvc;

namespace app_enquete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnqueteController : BaseController
    {
        private IRepositorio<Poll> pollRepositorio = null;
        private IRepositorio<View> viewRepositorio = null;
        private PollServices pollServices = null;
        private ViewServices viewServices = null;
        public EnqueteController()
        {
            this.unitOfWork =  UnitOfWork.GetInstanceLazyLoad(base.contexto);
            this.pollRepositorio = base.unitOfWork.PollRepositorio;
            this.viewRepositorio = base.unitOfWork.ViewRepositorio;

            this.pollServices = new PollServices(this.pollRepositorio, this.viewRepositorio);
            this.viewServices = new ViewServices(this.viewRepositorio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Poll poll)
        {
            try
            {
                var retorno = await this.pollServices.Create(poll);
                if (retorno != null)
                    return Ok(retorno);

                return Ok("Erro ao salvar a enquente");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

      
        [HttpGet("{id:int}")]  // GET /api/Poll/1
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var retorno = await this.pollServices.Get(id);
                return Ok(retorno.Get());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet("{id:int}/poll")]
        public async Task<IActionResult> GetView(int id)
        {
            try
            {
                var retorno = await this.viewServices.GetCount(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet(Name = "gets")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var retorno = await this.pollServices.Gets();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Poll poll)
        {
            try
            {
                var _poll = await this.pollServices.Get(id);
                if (_poll == null)
                    return Ok("Erro ao atualizar a enquente");

                var retorno = await this.pollServices.Atualizar(poll);
                if (retorno != null)
                    return Ok(retorno);

                return Ok("Erro ao atualizar a enquente");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{id:int}")]  // GET /api/categoria/delete/1
        public async Task<IActionResult> Delete(short id)
        {
            try
            {
                var _categoria = await this.pollServices.Get(id);
                if (_categoria == null)
                    return Ok("Erro ao deletear a enquente");

                var retorno = await this.pollServices.Deletar(id);
                if (retorno > 0)
                    return Ok(retorno);

                return Ok("Erro ao deletar a enquente");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
