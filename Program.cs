// Rensa console
Console.Clear();

// Välkomna spelare till spelet och be dem välja namn på sin karaktär.
Console.WriteLine("Hej och välkommen till Gamla Skogen. En plats där faror kan lura bakom varje hörn!");
Console.WriteLine("Innan vi fortsätter, vad ska vi kalla dig?");

// Lagra valt namn till en variabel och kontrollera att namn inte lämnades tomt.
string? playerName = "";
while (playerName!.Length < 1)
{
    // Hämta användarens input och ge värdet till playerName
    playerName = Console.ReadLine();
    if (String.IsNullOrEmpty(playerName))
    {
        Console.Clear();
        // Om inget namn skrevs in, be spelaren skriva in ett namn.
        Console.WriteLine("Du måste ange ett namn!");
    }
    else
        // Fortsätt spel om namn har valts
        break;
}

// Initiera nytt player-objekt
Player player = new Player()
{
    // Deklarera det kontrollerade namnet till namn på objekt
    Name = playerName
};

// Initiera nytt random-objekt
Random random = new Random();

// Rensa konsoll och fortsätt spel
Console.Clear();
Console.WriteLine(player.Name + ", se upp!\nEn arg orch attackerar!");

// Initiera enemy-objekt och ge namn
Enemy firstEnemy = new Enemy("Arg orch");

// Initiera gameloop-objekt
Gameloop gameLoop = new Gameloop();

// Spel 1
gameLoop.startGame(firstEnemy, random, player, 10, 15, 20);

// Kontrollera att spelare inte har dött
if (!player.isDead)
{
    Boss boss = new Boss();
    // Spel 2
    gameLoop.startGame(boss, random, player, 20, 15, 20);

    // Kontrollera att spelare inte har dött
    if (!player.isDead)
    {
        Console.WriteLine("Grattis " + player.Name + ", du besegrade " + boss.Name + " och vann!");
    }
    // Om spelare har dött och förlorat, kör funktion GameOver som skriver ut att spelare förlorade.
    else
    {
        gameLoop.GameOver();
    }
}
// Om spelare har dött och förlorat, kör funktion GameOver som skriver ut att spelare förlorade.
else
{
    gameLoop.GameOver();
}

