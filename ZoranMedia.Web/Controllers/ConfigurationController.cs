using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService, UserManager<ApplicationUser> userManager)
        {
            _configurationService = configurationService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            IEnumerable<Configuration> configurations = await _configurationService.GetAllConfigurationsAsync();

            return View(configurations);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                await _configurationService.CreateConfigurationAsync(configuration);
                return RedirectToAction("Index");
            }
            return View(configuration);
        }
    }
}
