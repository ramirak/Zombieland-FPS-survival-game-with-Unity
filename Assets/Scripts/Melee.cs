class Melee
{
    private bool isOwned;

    public Melee(bool isOwned)
    {
        this.isOwned = isOwned;
    }

    public void setIsOwned(bool isOwned)
    {
        this.isOwned = isOwned;
    }
    public bool getIsOwned()
    {
        return isOwned;
    }
}