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
    }
}
