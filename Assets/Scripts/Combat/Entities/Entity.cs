using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat.Entities
{
    [SelectionBase]
    public class Entity : MonoBehaviour
    {
        // stats
        [SerializeField] private List<MoveSettings> moveSettings;
        [SerializeField] private int startingHealth = 5;
        [SerializeField] private Animator animator;

        private int _health;
        
        public List<MoveSettings> GetAllMoveSettings => moveSettings;
        public List<Move> GetAllMoves => moveSettings.Select(settings => settings.Data).ToList();

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
            if (moveSettings.Count != 0)
            {
                int index = Random.Range(0, moveSettings.Count - 1);
                yield return StartCoroutine(UseMove(moveSettings[0].Data, target));
            }
        }
        public IEnumerator UseMove(Move move, Entity target)
        {
            target.Damage(move.damage);
            Heal(move.healing);
            yield break;
        }
    }
}