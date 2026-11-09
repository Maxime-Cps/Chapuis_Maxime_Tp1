using Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;
using Chapuis_Maxime_Tp1.Models.SpaceShips;

namespace Chapuis_Maxime_Tp1.Models;

public class Player : IPlayer
{
    private string FirstName { get; }
    private string LastName { get; }
    public string Alias { get; }
    public Spaceship BattleShip { get; }
    public string Name { get; }

    public Player(string firstName, string lastName, string alias, Armory armory)
    {
        this.FirstName = FormatName(firstName);
        this.LastName = FormatName(lastName);
        this.Alias = alias;
        this.Name = $"{FirstName} {LastName}";
        this.BattleShip = new Spaceship("ViperMKII", 10, 15, armory);
    }

    private static string FormatName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        
        return name.Substring(0,1).ToUpper() + name.Substring(1).ToLower();
    }

    public override string ToString()
    {
        return $"{this.Alias} ({this.FirstName} {this.LastName})";
    }

    public override bool Equals(object? o)
    {
        if (o is not Player player)
        {
            return false;
        }
        
        return this.Alias == player.Alias;
    }

    public override int GetHashCode()
    {
        return this.Alias.GetHashCode();
    }
}