public class Gameloop
{
    public void startGame(Enemy enemy, Random random, Player player, int max_enemy_attack, int max_sword_attack, int max_bow_attack)
    {
        // Presentera möte med fiende
        Console.WriteLine("Du blir attackerad av en fiende, " + enemy.Name + "!");

        // While-loop som körs så länge både fiende och spelare lever
        while (!enemy.isDead && !player.isDead)
        {   
            // Presentera alternativ till spelaren
            Console.WriteLine("Vad vill du göra?\n\n1. Attackera med ditt svärd\n2. Attackera med din pilbåge\n3. Blockera attack\n4. Hela dig själv");
            // Skapa variabel som ska hålla spelaren val
            var playersAction = "";
            // While-loop som kör så länge spelarens input är tomt
            while (playersAction!.Length < 1)
            {
                // Lagra spelarens val i variabel
                playersAction = Console.ReadLine();
                // IF-sats som kollar om spelarens input är tomt
                if (string.IsNullOrEmpty(playersAction)) {
                    // Rensa konsolen
                    Console.Clear();
                    // Be användare välja ett alternativ från listan
                    Console.WriteLine("Du måste välja ett alternativ!");
                    Console.WriteLine("Vad vill du göra?\n\n1. Attackera med ditt svärd\n2. Attackera med din pilbåge\n3. Blockera attack\n4. Hela dig själv");
                } else 
                break;
            }
            {
                // Switch-statement som kör kod beroende på spelarens val
                switch (playersAction)
                {
                    // Körs om spelaren väljer 1
                    case "1":
                        // Rensa konsollen
                        Console.Clear();
                        // Skriv ut spelarens val 
                        Console.WriteLine("Du valde att attackera " + enemy.Name + " med ditt svärd!");
                        // Kör GetsHit-funktionen enemy-klassen
                        enemy.GetsHit(random.Next(1, max_sword_attack));

                        // Kontrollera om fienden är död
                        if (!enemy.isDead)
                        {
                            // Om fienden inte är död, fienden attackerar spelaren
                            player.GetsHit(random.Next(1, max_enemy_attack));
                        }
                        break;
                    // Körs om spelaren väljer 2
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Du valde att attackera med din pilbåge!");

                        enemy.GetsHit(random.Next(5, max_bow_attack));

                        // Kontrollera om fienden är död
                        if (!enemy.isDead)
                        {
                            // Om fienden inte är död, fienden attackerar spelaren
                            player.GetsHit(random.Next(1, max_enemy_attack));
                        }
                        break;
                    // Körs om spelaren väljer 3
                    case "3":
                        // Rensa konsolen   
                        Console.Clear();
                        // Skriv ut spelaren val
                        Console.WriteLine("Du valde att skydda dig!");

                        // Sätt boolean 
                        player.isDefending = true;

                        // Kontrollera om fienden är död
                        if (!enemy.isDead)
                        {   
                            // Om fienden inte är död, fienden attackerar spelaren
                            player.GetsHit(random.Next(1, max_enemy_attack));
                        }
                        break;
                    // Körs om spelaren väljer 4
                    case "4":
                        // Rensa konsolen   
                        Console.Clear();
                        // Skriv ut spelaren val
                        Console.WriteLine("Du valde att hela dig!");

                        // Kör heal-funktionen från player-klassen
                        player.Heal(random.Next(10, 30));
                        
                        // Kontrollera om fienden är död
                        if (!enemy.isDead)
                        {
                            // Om fienden inte är död, fienden attackerar spelaren
                            player.GetsHit(random.Next(1, max_enemy_attack));
                        }
                        break;
                    // Körs om spelaren inte skriver i 1, 2, 3 eller 4
                    default:

                        Console.Clear();
                        Console.WriteLine("Välj ett alternativ från listan!");
                        break;
                }
            }
        }

    }
    // Spelet är förlorat
    public void GameOver()
    {
        Console.WriteLine("Du dog. GAME OVER!");
    }

}
