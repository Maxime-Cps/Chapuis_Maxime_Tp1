using Chapuis_Maxime_Tp1.Models.SpaceShips;

namespace Chapuis_Maxime_Tp1.Models;

public interface IPlayer
{
    string Name { get; }
    string Alias { get; }
    Spaceship BattleShip { get; }
}