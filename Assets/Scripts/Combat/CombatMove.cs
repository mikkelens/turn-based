using System;
using UnityEngine;

namespace Gameplay.Management
{
    public class CombatMove : ScriptableObject
    {
        public string attackName;
        public int damage;
        public int healing;
        public int maxUses;
        
        public CombatMove
        (
            string attackName = "Unnamed attack type",
            int damage = 1,
            int healing = 0,
            int maxUses = -1
        )
        {
            this.attackName = attackName;
            this.damage = damage;
            this.healing = healing;
            this.maxUses = maxUses;
        }
    }
}