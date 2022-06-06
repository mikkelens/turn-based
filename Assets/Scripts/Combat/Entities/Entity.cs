using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat.Entities
{
    [SelectionBase]
    public class Entity : MonoBehaviour
    {
        // stats
        [SerializeField] private List<MoveData> moves;
        [SerializeField] private int startingHealth = 5;
        [SerializeField] private Animator animator;

        private int _health;


        public List<MoveData> GetMoves => moves;

        public void Heal(int amount)
        {
            _health += amount;
        }
        public void Damage(int amount)
        {
            _health -= amount;
        }
        
        public bool Alive => _health > 0;

        [Button]
        public void ResetHealth()
        {
            Debug.Log($"{name} health reset to {startingHealth.ToString()}, was {_health.ToString()}");
            _health = startingHealth;
        }

        public IEnumerator UseRandomMove(Entity target)
        {
            if (moves.Count != 0)
            {
                int index = Random.Range(0, moves.Count - 1);
                yield return StartCoroutine(UseMove(index, target));
            }
        }
        public IEnumerator UseMove(int moveIndex, Entity target)
        {
            MoveData moveData = moves[moveIndex];
            
            target.Damage(moveData.damage);
            Heal(moveData.healing);
            yield break;
        }
    }
}