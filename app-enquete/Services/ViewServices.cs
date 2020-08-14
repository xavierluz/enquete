using app_enquete.Domain;
using app_enquete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Services
{
    public class ViewServices
    {
        private IRepositorio<View> repositorio;

        public ViewServices(IRepositorio<View> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<View> Create(View view)
        {
            try
            {
                if (view == null)
                {
                    throw new NullReferenceException("Verificar dados da opção da enquente, o mesmo está vazio");
                }
                await this.repositorio.Insert(view);
                var registros = await this.repositorio.Save();

                return view;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<View> Get(int id)
        {

            try
            {
                var resultado = await this.repositorio.Get(x => x.PollId == id, "Poll");
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        public async Task<int> GetCount(int pollId)
        {

            try
            {
                var resultado = await this.repositorio.GetCount(x => x.PollId == pollId);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

    }
}
