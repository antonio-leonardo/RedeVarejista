using Microsoft.AspNetCore.Mvc;
using Rede.Varejista.Domain.Services.Facade;

namespace Rede.Varejista.WebApi.Controllers
{
    public class RedeVarejistaControllerBase : ControllerBase
    {
        protected internal readonly CategoriaCommandServiceFacade _categoriaCommandServiceFacade;

        protected internal readonly CategoriaQueryServiceFacade _categoriaQueryServiceFacade;

        public RedeVarejistaControllerBase(CategoriaCommandServiceFacade categoriaCommandServiceFacade, CategoriaQueryServiceFacade categoriaQueryServiceFacade)
        {
            this._categoriaCommandServiceFacade = categoriaCommandServiceFacade;
            this._categoriaQueryServiceFacade = categoriaQueryServiceFacade;
        }
    }
}
