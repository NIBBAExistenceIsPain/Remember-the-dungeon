using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player
    {
        string PlayerName;
        int hearths;
        public Vector2 CurrentLocation { get; set; }
        public Facing FacingDirection { get; set; }

        public Player(string name, int hearths)
        {
            this.PlayerName = name;
            this.hearths = hearths;
            FacingDirection = Facing.S;
            CurrentLocation = new Vector2(15, 2);
        }

        public string GetName()
        {
            return PlayerName;
        }

        public void TakeHit()
        {
            hearths--;
        }

        public void Heal()
        {
            hearths++;
        }

        public int GetHealth()
        {
            return hearths;
        }
    }
}
