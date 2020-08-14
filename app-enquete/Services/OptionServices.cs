using app_enquete.Domain;
using app_enquete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Services
{
    public class OptionServices
    {
        private IRepositorio<Option> repositorio;

        public OptionServices(IRepositorio<Option> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Option> Create(Option option)
        {
            try
            {
                if (option == null)
                {
                    throw new NullReferenceException("Verificar dados da enquente, o mesmo está vazio");
                }
                await this.repositorio.Insert(option);
                var registros = await this.repositorio.Save();

                return option;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
    }
}
