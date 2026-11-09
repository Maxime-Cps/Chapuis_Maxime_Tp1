namespace Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;

public class Armory
{
    public List<Weapon> Weapons;
    
    public Armory()
    {
        Init();
    }

    private void Init()
    {
        this.Weapons = new List<Weapon>();
        this.Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
        this.Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2));
        this.Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        this.Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
        this.Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 2));
        this.Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
    }

    public void ViewArmory()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Armory :");
        foreach (Weapon w in this.Weapons)
        {
            Console.WriteLine(w.ToString());
        }
    }

    public bool Contains(Weapon weapon)
    {
        return Weapons.Exists(w => w.Name == weapon.Name);
    }
}