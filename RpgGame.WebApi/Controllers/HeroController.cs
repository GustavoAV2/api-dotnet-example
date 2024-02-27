using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgGame.Domain.Entities;
using RpgGame.Repository;

namespace RpgGame.WebApi.Controllers
{
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;
        private readonly IEFCoreRepository _repo;

        public HeroController(ILogger<HeroController> logger, IEFCoreRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public ActionResult SaveHero(Hero hero)
        {
            _repo.Add(hero);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutHero(long id, Hero hero) { 
            if (_repo.Heroes.AsNoTracking().FirstOrDefault(u => u.Id == id) != null)
            {
                _repo.Update(hero);
                return Ok();
            }
            return Ok("Not Found!");
        }

        [HttpGet]
        public ActionResult<List<Hero>> GetHeroes()
        {
            var heroes = _repo.Heroes.ToList();
            return Ok(heroes);
        }
    }
}
