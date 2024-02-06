
namespace RpgGame.Domain.Entities
{
    public class Weapon
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
