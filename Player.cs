
public class Player
{
    // Properties
    public int Health { get; set; }
    public string? Name { get; set; }
    public Boolean isDead { get; set; }
    public bool isDefending { get; set; }

    // Constructor
    public Player()
    {
        Health = 100;
    }

    // Funktion som körs när spelare blir attackerad
    public void GetsHit(int hit_value)
    {
        // Kontrollera om spelaren blockerar
        if (isDefending)
        {
            Console.WriteLine(Name + " blockerade sig och tog ingen skada!");
            isDefending = false;
        }
        // Om spelare inte blockerar
        else
        {
            Health = Health - hit_value;

            Console.WriteLine(Name + " tog " + hit_value + " skada!");
        }
        // Kontrollerar om spelare lever
        if (Health <= 0)
        {
            Die();
        }
        // Om spelare lever, skriv ut hur mycket HP spelaren har kvar.
        else
        {
            Console.WriteLine("Du har nu " + Health + " HP kvar.");
        }
    }

    // Funktion som körs om spelare väljer att hela sig 
    public void Heal(int heal_value)
    {
        // Öka health med värdet på medskickat argument
        Health = Health + heal_value;

        // Kontroll att Health inte överstiger 100.
        if (Health > 100)
        {
            Health = 100;
        }
        // Skriv ut hur mycket spelaren helade sig och hur mycket HP spelaren har kvar.
        Console.WriteLine(Name + " har healat sig " + heal_value + " HP. Du har nu " + Health + " HP kvar!");
    }

    // Funktion som körs om spelaren dör.
    public void Die()
    {
        Console.WriteLine("Åh nej, du har dött!");
        isDead = true;
    }
}