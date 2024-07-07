using UnityEngine;
using System.Collections;

public static class Fight {




    /// <summary>
    /// This Method decides which entity has to fight against which enemy.
    /// an returns the loosers of the decided fight.
    /// </summary>
    /// <param name="attacker">The Player that enters a field, were another Player is sitting.</param>
    /// <param name="defender">The Player that sits in the field.</param>
    /// <returns></returns>
    public static Player PlayerVsPlayer(Player attacker, Player defender)
    {
        int chooseFight = UnityEngine.Random.Range(1, 2); // A random-value between 0 and 100 gets generated. this random value will be used to decide which fighting-mod gets chosen
        int randomBonusAttacker = UnityEngine.Random.Range(1, 500);  // a random value between 0 and 500 gets generated, this will be the bonus-attack value of the attacker
        int randomBonusDefender = UnityEngine.Random.Range(1, 500); // a random value betwenn 0 and 500 gets generated, this will be the bonus-defense of the defender
        chooseFight = 1;
        if (chooseFight == 1)                           // Player vs Player
        {
            if ((attacker.attack + randomBonusAttacker) > (defender.defense + randomBonusDefender))
            {
                return defender;
            }
            else
            {
                return attacker;
            }


        }
        else if (chooseFight == 2) // Player-Dragon vs Player-Dragon
        {
            if ((attacker.playerDragon.attack + randomBonusAttacker) > (defender.playerDragon.defense + randomBonusDefender))
            {
                return defender;
            }
            else
            {
                return attacker;
            }

        }
        else                                             // Player and his Dragon vs Player and his Dragon
        {
            if ((attacker.attack + attacker.playerDragon.attack + randomBonusAttacker) > (defender.defense + defender.playerDragon.defense + randomBonusDefender))
            {
                return defender;
            }
            else
            {
                return attacker;
            }
        }


    }

    /// <summary>
    /// The fight of a player against an NPC enemy.
    /// </summary>
    /// <param name="attacker">The Player that entered the field were the enemy is standing.</param>
    /// <param name="defender">The NPC that sits in his field.</param>
    /// <returns></returns>
    public static bool PlayerVsNPC(Player attacker, NPC defender)
    {
        bool won = false;
        int randomBonusAttacker = UnityEngine.Random.Range(1, 500);  // a random value between 0 and 500 gets generated, this will be the bonus-attack value of the attacker
        int randomBonusDefender = UnityEngine.Random.Range(1, 500); // a random value betwenn 0 and 500 gets generated, this will be the bonus-defense of the defender

        if ((attacker.attack + randomBonusAttacker) > (defender.defense + randomBonusDefender))
        {
            return won = true;
        }
        else
        {
            return won;
        }
    }
}
