using Microsoft.AspNetCore.Mvc;
using RpgGame.Domain.Dto;
using RpgGame.Domain.Entities;
using RpgGame.Repository;

namespace RpgGame.WebApi.Controllers
{
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly ILogger<BattleController> _logger;
        private readonly DatabaseContext _databaseContext;

        public BattleController(ILogger<BattleController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> SaveBattle(BattleDto battle)
        {
            var newBattle = new Battle { Name = battle.Name, CreatedDate = DateTime.Now };
            await _databaseContext.Battles.AddAsync(newBattle);
            _databaseContext.SaveChanges();
            await _databaseContext.HeroesBattles.AddAsync(new HeroBattle { BattleId = newBattle.Id, HeroId = battle.HeroId });
            _databaseContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Battle>> GetBattles()
        {
            var battles = _databaseContext.Battles.ToList();
            return Ok(battles);
        }
    }
}
