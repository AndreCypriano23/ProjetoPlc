using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoPLC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPLC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CorporeContext _corporedb;
        private readonly ILogger<HomeController> _logger;
     

        public HomeController(CorporeContext context, ILogger<HomeController> logger)
        {
            _corporedb = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var plcs = _corporedb.Plcs.ToList();

            return View(plcs);
        }

        //[HttpPut("{id}")]
        public IActionResult Mudar(int id)
        {
            try
            {
                //var selecionado = _corporedb.Plcs.Where(m => m.Selecionado).Select(m => m.Id);
                //Plc mudarInterlook = (Plc)_corporedb.Plcs.Where(p => p.Id == id);

                var plc = _corporedb.Plcs.FirstOrDefault(p => p.Id == id); 

                if(plc != null)
                {
                    if(plc.Interlook == 0)
                    {
                        plc.Interlook = 1;
                    }
                    else
                    {
                        plc.Interlook = 0;
                    }
                    

                    _corporedb.SaveChanges();
                }
                  

                return Ok(plc);
            }
            catch
            {
                return NotFound();
            }
         
            
         
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
