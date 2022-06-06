using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(menuName = "Combat/MoveSettings", fileName = "Unnamed Move Settings")]
    public class MoveData : ScriptableObject
    {
        public string moveName;
        public int damage;
        public int healing;

        public MoveData // default parameters
        (
            string moveName = "Unnamed move",
            int damage = 1,
            int healing = 0
        )
        {
            this.moveName = moveName;
            this.damage = damage;
            this.healing = healing;
        }
    }
}