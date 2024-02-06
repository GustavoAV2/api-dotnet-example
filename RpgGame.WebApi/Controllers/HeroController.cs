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

        [HttpPut]
        public ActionResult PutHero(long id, Hero hero) { 
            if (_databaseContext.Heroes.AsNoTracking().FirstOrDefault(u => u.Id == id) != null)
            {
                _databaseContext.Update(hero);
                _databaseContext.SaveChanges();
                return Ok();
            }
            return Ok("Not Found!");
        }

        [HttpGet]
        public ActionResult<List<Hero>> GetHeroes()
        {
            var heroes = _databaseContext.Heroes.ToList();
            return Ok(heroes);
        }
    }
}
