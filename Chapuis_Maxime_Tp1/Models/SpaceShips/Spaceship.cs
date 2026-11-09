using Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;

namespace Chapuis_Maxime_Tp1.Models.SpaceShips;

public class Spaceship : ISpaceship
{
    public string Name { get; }
    public double MaxStructure { get; }
    public double MaxShield { get; }
    public double CurrentStructure { get; private set; }
    public double CurrentShield { get; private set; }
    public bool IsDestroyed => CurrentStructure <= 0;
    public double AverageDamages
    {
        get
        {
            double total = 0;
            foreach (Weapon w in _weapons)
            {
                total += w.AverageDamage;
            }

            return total;
        }
    }
    public int MaxWeapons { get; } = 3;

    private readonly List<Weapon> _weapons;

    public IReadOnlyList<Weapon> Weapons => _weapons;
    
    // ISpaceship.AddWeapon ne prend que l'arme en paramètre, le vaisseau doit donc déjà connaître l'armurerie à consulter.
    // J'ai donc ajouté un paramètre au consructeur.
    private readonly Armory _armory;

    public Spaceship(string name, double maxStructure, double maxShield, Armory armory)
    {
        this.Name = name;
        this.MaxStructure = maxStructure;
        this.MaxShield = maxShield;
        this.CurrentStructure = maxStructure;
        this.CurrentShield = maxShield;
        this._weapons = new List<Weapon>(MaxWeapons);
        this._armory = armory;
    }

    public void AddWeapon(Weapon weapon)
    {
        if (!_armory.Contains(weapon))
        {
            throw new ArmoryException($"{weapon.Name} is not in the armory");
        }
        
        if (_weapons.Count >= MaxWeapons)
        {
            throw new InvalidOperationException("Cannot add more than " + MaxWeapons + " weapons");
        }
        
        _weapons.Add(weapon);
    }

    // List.Remove trouve l'élément à retirer grâce à Equals.
    // Weapon redéfinit Equals sur Name : un autre objet dans la liste avec le même nom est retiré.
    // Sans cette redéfinition, Equals compare les références et cette instance ne serait pas trouvée.
    public void RemoveWeapon(Weapon weapon)
    {
        _weapons.Remove(weapon);
    }

    public void ClearWeapons()
    {
        _weapons.Clear();
    }

    public void ViewWeapons()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Weapons installed :");
        foreach (Weapon w in _weapons)
        {
            Console.WriteLine(w.ToString());
        }
    }

    public void ViewShip()
    {
        Console.WriteLine(" ");
        Console.WriteLine("BattleShip :");
        string display = $"{Name} - Structure State = {CurrentStructure}/{MaxStructure} - Shield State {CurrentShield}/{MaxShield} - Average Damages : {this.AverageDamages}";
        Console.WriteLine(display);
        ViewWeapons();
    }

}