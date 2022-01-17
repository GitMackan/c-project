// Denna klass ärver alla egenskaper och funktioner från klass Enemy.
// Förutom de ärvda egenskaperna så väljs bossens Health och Namn i klassens constructor.
public class Boss : Enemy
{
    // Constructor
    public Boss() : base("Boss Sauron")
    {
        Health = 150;
    }
}