using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public enum EnemyType
    {
        Slime,
        Skelly,
        BlueBoss,
        GreenBoss,
        RedBoss,
        BossBoss
    }

    public class Enemy
    {
        public int moveCount { get; set; }
        public int moveDelay { get; set; }
        public int hitPoints { get; set; }
        public float speed { get; set; }
        public EnemyType type { get; set; }

        public Enemy(int moves, int moveDelay, int hitPoints, float speed, EnemyType type)
        {
            moveCount = moves;
            this.moveDelay = moveDelay;
            this.hitPoints = hitPoints;
            this.speed = speed;
            this.type = type;
        }

        public static Enemy GenerateEnemy()
        {
            Random rng = new Random();
            EnemyType type;
            if (rng.Next(3) == 1) type = EnemyType.Skelly;
            else type = EnemyType.Slime;
            return new Enemy(rng.Next(2, 4), 1, rng.Next(2, 5), rng.Next(1, 2), type);
        }

        public static Enemy GenerateMiniBoss(EnemyType boss)
        {
            Random rng = new Random();
            return new Enemy(rng.Next(4, 6), 1, rng.Next(6, 12), rng.Next(2, 3), boss);
        }

        public static Enemy GenerateBoss()
        {
            return new Enemy(12, 1, 25, 4, EnemyType.BossBoss);
        }

    }
}
