using Microsoft.AspNetCore.Mvc;
using RpgGame.Domain.Entities;
using RpgGame.Repository;

namespace RpgGame.WebApi.Controllers
{
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;
        private readonly DatabaseContext _databaseContext;

        public HeroController(ILogger<HeroController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public ActionResult SaveHero(Hero hero)
        {
            _databaseContext.Heroes.Add(hero);
            _databaseContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Hero>> GetHeroes()
        {
            var heroes = _databaseContext.Heroes.ToList();
            return Ok(heroes);
        }
    }
}
