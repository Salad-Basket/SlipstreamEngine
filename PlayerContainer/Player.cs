namespace SlipstreamEngine.PlayerContainer;
public  class Player
{
    public float health { get; private set; }
    public float speed { get; private set; }

    public Player(float health = 0f, float speed = 0f)
    {
        this.health = health;
        this.speed = speed;
    }

    public bool damage(float damage)
    {
        this.health -= damage;
        return true;
    }

    public bool deathCheck()
    {
        if(this.health <= 0f) return true;
        return false;
    }
}
