using app_enquete.Domain;
using app_enquete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Services
{
    public class PollServices
    {
        private IRepositorio<Poll> pollRepositorio;
        private IRepositorio<View> viewRepositorio;
        public PollServices(IRepositorio<Poll> pollRepositorio)
        {
            this.pollRepositorio = pollRepositorio;
        }
        public PollServices(IRepositorio<Poll> pollRepositorio, IRepositorio<View> viewRepositorio)
        {
            this.pollRepositorio = pollRepositorio;
            this.viewRepositorio = viewRepositorio;
        }
       
        public async Task<Poll> Create(Poll poll)
        {
            try
            {
                if(poll == null)
                {
                    throw new NullReferenceException("Verificar dados da enquente, o mesmo está vazio");
                }
                await this.pollRepositorio.Insert(poll);
                var registros = await this.pollRepositorio.Save();

                return poll;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<Poll> Vote(Poll poll)
        {
            try
            {
                if (poll == null)
                {
                    throw new NullReferenceException("Verificar dados da enquente, o mesmo está vazio");
                }


                await this.pollRepositorio.Insert(poll);
                var registros = await this.pollRepositorio.Save();

                return poll;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<Poll> Atualizar(Poll poll)
        {
            try
            {
                if (poll == null)
                {
                    throw new NullReferenceException("Verificar dados da enquente, o mesmo está vazio");
                }

                await this.pollRepositorio.Update(poll);
                var registros = await this.pollRepositorio.Save();

                return poll;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<int> Deletar(int id)
        {
            try
            {
                await this.pollRepositorio.Delete(id);
                var registros = await this.pollRepositorio.Save();

                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<Poll> Get(int id)
        {

            try
            {
                var resultado = await this.pollRepositorio.Get(id);
                if(resultado == null)
                {
                    return null;
                }
                View view = new View()
                {
                    PollId = id
                };
      
                await this.viewRepositorio.Insert(view);
                await this.viewRepositorio.Save();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<IEnumerable<Poll>> Gets()
        {
            try
            {
                this.pollRepositorio.SetLazyLoader(true);
                var resultado = await this.pollRepositorio.Gets("Options,Vote");

                return resultado.ToList().ConvertAll(new Converter<Poll, Poll>(x => x.Get()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
