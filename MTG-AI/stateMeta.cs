using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    public class stateMeta
    {
        public const float pLifeScore = 0.5f;//set positive
        public const float eLifeScore = -0.5f;//set negative
        public const float powerScore = 0.5f;//set positive
        public const float toughScore = 0.25f;//set positive
        public const float manaScore = 0.1f;//set positive
        public const float uCreatScore = 1.0f;//set positive
        public const float eCreatScore = -0.5f;//getting more creatures is positive value, so set a negative score
        public const float ePowerScore = -0.5f;
        public const float eToughScore = -0.25f;


        public int playerLife;
        public int enemyLife;
        public int totalPow;
        public int totalTough;
        public int totalMana;
        public int usCreatureCount;
        public int enemyCreatureCount;
        public int enemyTotalPow;
        public int enemyTotalTough;

        public stateMeta()
        {
            playerLife = 0;
            enemyLife = 0;
            totalPow = 0;
            totalTough = 0;
            totalMana = 0;
            usCreatureCount = 0;
            enemyCreatureCount = 0;
            enemyTotalPow = 0;
            enemyTotalTough = 0;
        }
    }
}
