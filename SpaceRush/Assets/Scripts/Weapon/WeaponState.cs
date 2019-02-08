public abstract class WeaponState
{
    protected Weapon weapon;

    public abstract void Tick();

    public abstract void OnStateEnter();
    public abstract void OnStateExit();

    public WeaponState(Weapon weapon)
    {
        this.weapon = weapon;
    }
}