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
        private readonly EFCoreRepository _repo;

        public BattleController(ILogger<BattleController> logger, EFCoreRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> SaveBattle(BattleDto battle)
        {
            try
            {
                var newBattle = new Battle { Name = battle.Name, CreatedDate = DateTime.Now };
                _repo.Add(newBattle);
                _repo.Add(new HeroBattle { BattleId = newBattle.Id, HeroId = battle.HeroId });
                if (await _repo.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Não foi possivel salvar!");
        }

        [HttpGet]
        public ActionResult<List<Battle>> GetBattles()
        {
            var battles = _repo.GetAll<Battle>();
            return Ok(battles);
        }
    }
}
