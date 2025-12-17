using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services;
using M2Corte2025.FormationFred.Services.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        BRecipesContext context;
        public RecipesController(BRecipesContext ctx)
        {
            context = ctx;
        }

        [HttpGet()]
        public List<Recipe> GetAll()
        {
            Factory.Instance.Context = context;
            return Factory.Instance.GetAll();
        }
    }
}
