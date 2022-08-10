using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Data.InterfaceRepository;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Controllers
{
    public class RaceController: Controller
    {
        private readonly IRaceRepository _raceRepository;
        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.getAll();

            return View(races);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.getByIDAsync(id);
            return View(race);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Race race)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _raceRepository.add(race);
            return RedirectToAction("Index");
        }
    }
}
