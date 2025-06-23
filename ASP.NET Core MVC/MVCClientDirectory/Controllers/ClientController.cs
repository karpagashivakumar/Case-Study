using Microsoft.AspNetCore.Mvc;
using MVCClientDirectory.Models;
using System.Linq;

namespace MVCClientDirectory.Controllers
{
    public class ClientController : Controller
    {
        static List<ClientInfo> clients = new List<ClientInfo>
        {
            new ClientInfo
            {
                ClientId = 1,
                CompanyName = "Hexaware",
                WebURL = "www.hexa.com",
                Email = "prithiv2k03@gmail.com",
                Category = "Low_Level_Managed_IT_Services",
                Standard = "CMMI1"
            }
        };

        public IActionResult ShowAllClientsDetails()
        {
            return View(clients);
        }

        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);
            if (client == null)
                return View("ClientNotFound", $"Client with ID {id} not found.");

            return View(client);
        }

        public IActionResult GetDetailsByCompanyName(string companyName)
        {
            var client = clients.FirstOrDefault(c => c.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (client == null)
                return View("ClientNotFound", $"No client found with company name '{companyName}'");

            return View("GetDetailsByClientId", client);
        }

        [HttpGet]
        public IActionResult AddClients()
        {
            PopulateDropdowns();
            return View();
        }

      
        [HttpPost]
        
        public IActionResult AddClients(ClientInfo client)
        {
            client.ClientId = clients.Count > 0 ? clients.Max(c => c.ClientId) + 1 : 1;
            clients.Add(client);
            return RedirectToAction("ShowAllClientsDetails");
        }

        private void PopulateDropdowns()
        {
            ViewBag.CategoryOptions = new List<string>
            {
                "Low_Level_Managed_IT_Services",
                "Mid_Level_Managed_IT_Services",
                "High_Level_Managed_IT_Services",
                "On-Demand_IT_Services",
                "Hardware_Support",
                "Software Services",
                "Network_Management"
            };

            ViewBag.StandardOptions = new List<string>
            {
                "CMMI1", "CMMI2", "CMMI3", "CMMI4", "CMMI5", "ISO", "None"
            };
        }
    }
}
