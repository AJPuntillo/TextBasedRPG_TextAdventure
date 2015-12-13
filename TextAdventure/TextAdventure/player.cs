using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class player

    {
        //Setting the player variables
        public int playerHealth;
        public string playerName;
        public int playerLevel;
        public int playerScore;
        public int playerAttack;
        public string playerWeapon;

        //Creating the default values of the player
        public player()
        {
            playerHealth = 100;
            playerName = "Player";
            playerLevel = 1;
            playerAttack = 15;
            playerWeapon = "Trainer's Broadsword";
            playerScore = 0;
        }

        //Setting the player's values through input
        public player(int pHealth, string pName, int pLevel, int pScore, int pAttack, string pWeapon)
        {
            playerHealth = pHealth;
            playerName = pName;
            playerLevel = pLevel;
            playerScore = pScore;
            playerAttack = pAttack;
            playerWeapon = pWeapon;
        }
    }
}
