
namespace RpgGame.Domain.Entities
{
    public class HeroBattle
    {
        public long BattleId { get; set; }
        public long HeroId { get; set; }
        public Battle Battle { get; set; }
        public Hero Hero { get; set; }
    }
}
