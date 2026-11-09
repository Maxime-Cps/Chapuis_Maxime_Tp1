namespace Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;

public class Weapon : IWeapon
{
    public string Name { get; }
    public double MinDamage { get; }
    public double MaxDamage { get; }
    public EWeaponType Type { get; }
    public double AverageDamage { get; }
    public int ReloadTime { get; }
    public int TimeBeforeReload { get; private set; }
    public bool IsReady => TimeBeforeReload == 0;

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType type, int reloadTime)
    {
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.Type = type;
        this.AverageDamage = (MinDamage + MaxDamage) / 2;
        if (type == EWeaponType.Explosive)
        {
            this.ReloadTime = reloadTime * 2;
        }
        else
        {
            this.ReloadTime = reloadTime;
        }
        this.TimeBeforeReload = this.ReloadTime;
    }

    public override string ToString()
    {
        return $"{this.Name} - ({this.Type}) weapon : {this.AverageDamage} damage";
    }
    
    public override bool Equals(object? o)
    {
        if (o is not Weapon weapon)
        {
            return false;
        }
        
        return this.Name == weapon.Name;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public void DecrementReload()
    {
        if (this.TimeBeforeReload > 0)
        {
            this.TimeBeforeReload -= 1;
        }
    }

    public double Shoot()
    {
        if (!IsReady)
        {
            return 0;
        }

        TimeBeforeReload = ReloadTime;
        double damage = RandomDamage();
        
        switch (Type)
        {
            case EWeaponType.Direct:
                if (Random.Shared.Next(10) == 0)
                {
                    return 0;
                }
                return damage;
            case EWeaponType.Explosive:
                if (Random.Shared.Next(4) == 0)
                {
                    return 0;
                }
                return damage * 2;
            case EWeaponType.Guided:
                return MinDamage;
        }
        return damage;
    }
    
    private double RandomDamage()
    {
        return MinDamage + Random.Shared.NextDouble() * (MaxDamage - MinDamage);
    }
}