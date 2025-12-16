using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet()]
        public List<Recipe> GetAll()
        {
            return Factory.Instance.GetAll();
        }
    }
}
