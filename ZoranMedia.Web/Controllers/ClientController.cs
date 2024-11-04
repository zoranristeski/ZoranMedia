using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Web.Controllers
{
    public class ClientController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IClientService _clientService;
        public ClientController(IClientService clientService, UserManager<ApplicationUser> userManager)
        {
            _clientService = clientService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            IEnumerable<Client> clients = await _clientService.GetAllClientsAsync();

            return View(clients);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.CreateClientAsync(client);
                return RedirectToAction("Index"); 
            }
            return View(client);
        }
    }
}
