using Microsoft.AspNetCore.Mvc;
using RpgGame.Domain.Entities;
using RpgGame.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RpgGame.WebApi.Controllers
{
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly ILogger<BattleController> _logger;
        private readonly IEFCoreRepository<Battle> _repo;

        public BattleController(ILogger<BattleController> logger, IEFCoreRepository<Battle> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> SaveBattle(Battle battle)
        {
            try
            {
                _repo.Add(battle);

                if (await _repo.SaveChangeAsync())
                {
                    _logger.LogInformation("Battle saved: {battle}", battle);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save battle: {battle}", battle);
                return BadRequest(ex.Message);
            }

            _logger.LogError("Failed to save battle: {battle}", battle);
            return BadRequest("Failed to save battle");
        }

        [HttpGet]
        public async Task<ActionResult<List<Battle>>> GetBattles()
        {
            var battles = await _repo.GetAllAsync();
            _logger.LogInformation("Retrieved {count} battles", battles.Count());
            return Ok(battles);
        }
    }
}
