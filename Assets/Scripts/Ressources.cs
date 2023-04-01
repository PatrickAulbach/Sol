public class Ressources
{
    public int minerals {get; set;}
    public int food {get; set;}
    public int gold {get; set;}

    public Ressources(int minerals, int food, int gold)
    {
        this.minerals = minerals;
        this.food = food;
        this.gold = gold;
    }

    public Ressources() {}
}
