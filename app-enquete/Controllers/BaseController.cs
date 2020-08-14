using app_enquete.contexto;
using app_enquete.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Controllers
{
    public class BaseController: ControllerBase
    {
        private ContextoFactory factory = new ContextoFactory();
        protected Contexto contexto = null;
        protected UnitOfWork unitOfWork = null;
        public BaseController()
        {
            this.contexto = factory.CreateDbContext(null);
        }
    }
}
