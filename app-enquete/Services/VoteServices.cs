using app_enquete.Domain;
using app_enquete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Services
{
    public class VoteServices
    {
        private IRepositorio<Vote> repositorio;

        public VoteServices(IRepositorio<Vote> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Vote> Create(Vote vote)
        {
            try
            {
                if (vote == null)
                {
                    throw new NullReferenceException("Verificar dados do voto da enquente, o mesmo está vazio");
                }
                await this.repositorio.Insert(vote);
                var registros = await this.repositorio.Save();

                return vote;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<Vote> Get(int id)
        {
            try
            {
                var resultado = await this.repositorio.Get(id);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

    }
}
