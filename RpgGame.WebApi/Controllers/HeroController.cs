using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RpgGame.Domain.Entities;
using RpgGame.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpgGame.WebApi.Controllers
{
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;
        private readonly IEFCoreRepository<Hero> _repo;

        public HeroController(ILogger<HeroController> logger, IEFCoreRepository<Hero> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> SaveHero(Hero hero)
        {
            try
            {
                _repo.Add(hero);
                _logger.LogInformation("Hero created: {hero}", hero);

                if (await _repo.SaveChangeAsync())
                {
                    _logger.LogInformation("Hero saved: {hero}", hero);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save hero: {hero}", hero);
                return BadRequest(ex.Message);
            }

            _logger.LogError("Failed to save hero: {hero}", hero);
            return BadRequest("Failed to save hero");
        }

        [HttpPut]
        public ActionResult PutHero(long id, Hero hero)
        {
            hero.Id = id;
            _repo.Update(hero);

            _logger.LogInformation("Hero updated: {hero}", hero);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetHeroes()
        {
            var heroes = await _repo.GetAllAsync();

            _logger.LogInformation("Retrieved {count} heroes", heroes.Count());
            
            return Ok(heroes);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHero(string id)
        {
            var hero = await _repo.GetByIdAsync(id);

            if (hero != null)
            {
                _repo.Delete(hero);

                _logger.LogInformation("Hero deleted: {hero}", hero);

                return Ok();
            }

            return NotFound();
        }
    }
}
