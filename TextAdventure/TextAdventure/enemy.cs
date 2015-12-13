using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class enemy
    {
        public int enemyHealth;
        public string enemyName;
        public int enemyAttack;
        public string enemyWeapon;

        //Creating the default values of the player
        public enemy()
        {
            enemyHealth = 50;
            enemyName = "Orc Bandit";
            enemyAttack = 10;
            enemyWeapon = "Battered Battle Axe";
        }

        //Setting the player's values through the user
        public enemy(int eHealth, string eName, int eAttack, string eWeapon)
        {
            enemyHealth = eHealth;
            enemyName = eName;
            enemyAttack = eAttack;
            enemyWeapon = eWeapon;
        }
    }
}
