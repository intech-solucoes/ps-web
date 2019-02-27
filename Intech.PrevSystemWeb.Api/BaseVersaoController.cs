#region Usings
using Intech.PrevSystemWeb.Api;
using Microsoft.AspNetCore.Mvc;
using System.Reflection; 
#endregion

namespace Intech.PrevSystemWeb.Cageprev.Api.Controllers
{
    public class BaseVersaoController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName();
            return Json(version.Version.ToString(3));
        }
    }
}