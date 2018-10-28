using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using KargorERP.Services.Resources;

namespace KargorERP.Controllers
{
    // [ApiController]
    public class ResourceController<T> : Controller where T : class
    {
        protected ResourceService<T> _resourceService;

        public ResourceController(ResourceService<T> resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<List<T>> Index()
        {
            return await _resourceService.FetchAll();
        }

        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        public async Task<IActionResult> CreateMany()
        {
            return Ok();
        }

        public async Task<IActionResult> View()
        {
            return Ok();
        }
    }
}