using Microsoft.AspNetCore.Mvc;
using parcial1_programacion3.Datos;
using parcial1_programacion3.Models;

namespace parcial1_programacion3.Controllers
{
    public class CompetidorController : Controller
    {
        CompetidoresDatos _BD = new CompetidoresDatos();
        public IActionResult Index()
        {
            return View(_BD.listarCompetidores());
        }

        public IActionResult Create()
        {
            ViewBag.Disciplina = _BD.ListarDisciplinas();
            return View();
        }
        [HttpPost]

        public IActionResult Create(Competidores competidor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _BD.Crear(competidor);
                if(ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            } 
            catch
            {
                return View();
            }
        }

        public IActionResult Participantes()
        {
            return View(_BD.listarCantidad());
        }
    }
}
