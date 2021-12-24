
public class Weapon
{
    private bool isOwned, isMeleeWeapon;
    private int maxAmmo, ammoLeft, damage, price;
    private string name;
    private float missRate;
    private const int missRateIncreasePer = 5;
    public Weapon(bool isOwned, bool isMeleeWeapon, int maxAmmo, int ammoLeft, float missRate, int damage, string name, int price)
    {
        this.isOwned = isOwned;
        this.isMeleeWeapon = isMeleeWeapon;
        this.maxAmmo = maxAmmo;
        this.ammoLeft = ammoLeft;
        this.missRate = missRate;
        this.damage = damage;
        this.name = name;
        this.price = price;
    }
    public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public int getDamage()
    {
        return damage;
    }
    public void setIsOwned(bool isOwned)
    {
        this.isOwned = isOwned;
    }
    public bool getIsOwned()
    {
        return isOwned;
    }
    public bool getIsMelee()
    {
        return isMeleeWeapon;
    }
    public void setAmmoLeft(int ammoLeft)
    {
        this.ammoLeft = ammoLeft;
    }
    public int getAmmoLeft()
    {
        return ammoLeft;
    }
    public int getMaxAmmo()
    {
        return maxAmmo;
    }

    public float getMissRate()
    {
        return missRate;
    }

    public int getMissRateIncrease()
    {
        return missRateIncreasePer;
    }

    public int getPrice()
    {
        return price;
    }

    public void setPrice(int price)
    {
        this.price = price;
    }

}