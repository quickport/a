using System;

namespace SimpleFighterGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("🎮 FIGHTER GAME STARTED!");
            Console.WriteLine("========================");
            
            Player player = new Player();
            
            while(player.IsAlive)
            {
                Console.WriteLine($"\nHealth: {player.Health} | Enemies: {player.EnemiesDefeated}");
                Console.Write("Press 'A' to attack, 'H' to heal, 'Q' to quit: ");
                
                string input = Console.ReadLine()?.ToUpper();
                
                switch(input)
                {
                    case "A":
                        player.Attack();
                        break;
                    case "H":
                        player.Heal();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Invalid input! Use A, H, or Q.");
                        break;
                }
            }
            
            Console.WriteLine($"\n💀 GAME OVER! You defeated {player.EnemiesDefeated} enemies!");
        }
    }
    
    public class Player
    {
        public int Health { get; set; } = 100;
        public int EnemiesDefeated { get; set; } = 0;
        public bool IsAlive => Health > 0;
        private Random random = new Random();
        
        public void Attack()
        {
            int enemyHealth = random.Next(20, 50);
            int playerDamage = random.Next(15, 30);
            
            Console.WriteLine($"⚔️ You attack for {playerDamage} damage!");
            enemyHealth -= playerDamage;
            
            if(enemyHealth <= 0)
            {
                EnemiesDefeated++;
                Console.WriteLine("🎯 Enemy defeated!");
                
                // Enemy counter-attack
                int enemyDamage = random.Next(5, 15);
                Health -= enemyDamage;
                Console.WriteLine($"💥 Enemy hits you for {enemyDamage} damage!");
                
                if(Health <= 0)
                {
                    Console.WriteLine("💀 You have been defeated!");
                }
            }
            else
            {
                Console.WriteLine($"🛡️ Enemy still has {enemyHealth} health!");
            }
        }
        
        public void Heal()
        {
            int healAmount = random.Next(10, 25);
            Health += healAmount;
            Console.WriteLine($"❤️ You heal for {healAmount} health!");
            
            // Enemy attacks while healing
            int enemyDamage = random.Next(5, 20);
            Health -= enemyDamage;
            Console.WriteLine($"💥 Enemy attacks you for {enemyDamage} damage while healing!");
            
            if(Health <= 0)
            {
                Console.WriteLine("💀 You have been defeated!");
            }
        }
    }
}