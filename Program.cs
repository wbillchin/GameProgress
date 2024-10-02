using System;

class GameProgress
{
    static void Main(string[] args)
    {
        // Initial player stats
        int health = 100;
        int energy = 50;
        int coins = 10;
        int xp = 0; // experience points
        int healthPotions = 5; // Starting health potions
        int level = 1; // Starting level
        const int xpToLevelUp = 100; // XP required to level up

        // Game event 1: The player finds a health potion (+25 health) but takes damage (-20 health)
        health += 25;
        health -= 20;

        // Game event 2: The player expends 10 energy to defeat an enemy, gains 15 XP and 5 coins
        energy -= 10;
        xp += 15; // Gain XP
        coins += 5;

        // Check for level-up after event 2
        CheckLevelUp(ref level, ref xp, xpToLevelUp);

        // Game event 3: The player uses a coin to buy a health potion (+1 potion) and drinks an energy drink (+10 energy)
        coins--;
        healthPotions += 1; // Gain a health potion
        energy += 10;

        // Game event 4: The player gains 30 more XP and reaches a level-up threshold at 45 XP
        xp += 30; // Gain more XP
        CheckLevelUp(ref level, ref xp, xpToLevelUp);

        // More complicated operations
        // Player loses 5 energy and consumes 1 health potion, health drops slightly
        --energy;
        energy -= 4;
        if (healthPotions > 0) // Check if the player has health potions
        {
            health += 20; // Use a health potion
            healthPotions--; // Reduce potion count
        }
        health = --health - 1; // Health decreases by 2 (prefix decrement + 1)

        // The player finds a rare item, gains 3 coins but uses 2 energy to retrieve it
        coins += 3;
        energy -= 2;

        // Checking if the player is tired (energy < 20) or poor (coins <= 5)
        bool isTired = energy < 20;
        bool isPoor = coins <= 5;

        // The player uses a healing item (if available) to regain health (+20) if tired or poor
        if (isTired || isPoor)
        {
            health += 20;
            if (healthPotions > 0) // Check if the player has health potions
            {
                healthPotions--; // Use a health potion
            }
        }

        // Additional Game Event: Check if the player's XP is even or if they have more than 50 coins
        if (xp % 2 == 0 && coins > 50)
        {
            Console.WriteLine("You have an even amount of XP and more than 50 coins! You're feeling lucky!");
            // Grant a bonus item or reward
            coins += 10; // Bonus coins
        }
        else
        {
            Console.WriteLine("You don't meet the special conditions for a bonus.");
        }

        // Final Game Event: The player gains 100 XP from completing a quest
        xp += 100; // Gain 100 XP
        CheckLevelUp(ref level, ref xp, xpToLevelUp);

        // Output the current stats
        Console.WriteLine($"Final Stats:");
        Console.WriteLine($"Health: {health}");
        Console.WriteLine($"Energy: {energy}");
        Console.WriteLine($"Coins: {coins}");
        Console.WriteLine($"XP: {xp}");
        Console.WriteLine($"Health Potions: {healthPotions}");
        Console.WriteLine($"Level: {level}");
    }

    static void CheckLevelUp(ref int level, ref int xp, int xpToLevelUp)
    {
        while (xp >= xpToLevelUp) // Check if enough XP for a level-up
        {
            level++;           // Level up
            xp -= xpToLevelUp; // Reduce XP by the amount needed to level up
            Console.WriteLine($"Congratulations! You've leveled up to Level {level}!");
        }
    }
}