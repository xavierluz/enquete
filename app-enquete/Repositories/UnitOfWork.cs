using app_enquete.contexto;
using app_enquete.Domain;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Repositories
{
    public class UnitOfWork: IDisposable
    {
        private Contexto contexto = null;
        private IRepositorio<Poll> pollRepositorio = null;
        private IRepositorio<Option> optionRepositorio = null;
        private IRepositorio<View> viewRepositorio = null;
        private IRepositorio<Vote> voteRepositorio = null;
        private bool lazyLoad = false;

        private UnitOfWork(Contexto contexto)
        {
            this.contexto = contexto;
        }
        private UnitOfWork(Contexto contexto, bool lazyLoad)
        {
            this.contexto = contexto;
            this.lazyLoad = true;
        }

        public static UnitOfWork GetInstance(Contexto contexto)
        {
            return new UnitOfWork(contexto);
        }
        public static UnitOfWork GetInstanceLazyLoad(Contexto contexto)
        {
            return new UnitOfWork(contexto, true);
        }

        public IRepositorio<Poll> PollRepositorio
        {
            get
            {

                if (this.pollRepositorio == null)
                {
                    this.pollRepositorio = Repositorio<Poll>.CreateLazyLoad(this.contexto);
                }
                return this.pollRepositorio;
            }
        }
        public IRepositorio<Vote> VoteRepositorio
        {
            get
            {

                if (this.voteRepositorio == null)
                {
                    this.voteRepositorio = Repositorio<Vote>.CreateLazyLoad(this.contexto);
                }
                return this.voteRepositorio;
            }
        }
        public IRepositorio<Option> OptionRepositorio
        {
            get
            {

                if (this.optionRepositorio == null)
                {
                    this.optionRepositorio = Repositorio<Option>.Create(this.contexto);
                }
                return this.optionRepositorio;
            }
        }
        public IRepositorio<View> ViewRepositorio
        {
            get
            {

                if (this.viewRepositorio == null)
                {
                    this.viewRepositorio = Repositorio<View>.Create(this.contexto);
                }
                return this.viewRepositorio;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
