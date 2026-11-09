namespace Chapuis_Maxime_Tp1.Models.SpaceInvadersArmory;

public interface IWeapon
{
    string Name { get; }
    EWeaponType Type { get; }
    double MinDamage { get; }
    double MaxDamage { get; }
    double AverageDamage { get; }
    int ReloadTime { get; }
    int TimeBeforeReload { get; }
    bool IsReady { get; }
    void DecrementReload();
    double Shoot();
}