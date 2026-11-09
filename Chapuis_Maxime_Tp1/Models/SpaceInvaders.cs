using System.Runtime.CompilerServices;
using Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;

namespace Chapuis_Maxime_Tp1.Models;

public class SpaceInvaders
{
    
    private List<Player> PlayersList;
    private Armory Armory;
    
    public SpaceInvaders()
    {
        Armory = new Armory();
        Init();
    }

    private void Init()
    {
        this.PlayersList = new List<Player>(); 
        this.PlayersList.Add(new Player("MaXIme", "CHapuis", "MESSMOCKY", Armory));
        this.PlayersList.Add(new Player("NiColas", "Tourneur", "G0SHIMA", Armory));
        this.PlayersList.Add(new Player("FOULQUES", "ChaPuis", "AveCapella", Armory));
    }

    static void Main(String[] args)
    {
        SpaceInvaders spaceInvaders = new SpaceInvaders();
        Player p1 = spaceInvaders.PlayersList[0];
        Armory armory = spaceInvaders.Armory;
        
        Console.WriteLine(" ");
        Console.WriteLine("Player list :");
        foreach (Player p in spaceInvaders.PlayersList)
        {
            Console.WriteLine(p.ToString());
        }
        armory.ViewArmory();
        p1.BattleShip.AddWeapon(armory.Weapons[0]);
        p1.BattleShip.AddWeapon(armory.Weapons[1]);
        p1.BattleShip.ViewShip();
        p1.BattleShip.AddWeapon(armory.Weapons[3]);

        try
        {
            p1.BattleShip.AddWeapon(armory.Weapons[4]);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            p1.BattleShip.AddWeapon(new Weapon("Death Ray", 50, 60, EWeaponType.Direct, 1));
        }
        catch (ArmoryException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}