public class Enemy
{
    // Properties
    public int Health { get; set; }
    public string Name { get; set; }
    public bool isDead { get; set; }

    // Constructor
    public Enemy(string name)
    {
        Health = 100;
        Name = name;
    }

    // Funktion som körs när fiende blir attackerad
    public void GetsHit(int hit_value)
    {
        Health = Health - hit_value;

        Console.WriteLine(Name + " tog " + hit_value + " skada!");

        // Kontrollera om fiende lever
        if (Health <= 0)
        {
            Die();
        }
        // Om spelare lever, skriv ut hur mycket HP spelaren har kvar.
        else
        {
            Console.WriteLine(Name + " har nu " + Health + " HP kvar.");
        }
    }

    // Funktion som körs när en fiende dör.
    private void Die()
    {
        Console.WriteLine(Name + " har besegrats!");

        isDead = true;
    }
}