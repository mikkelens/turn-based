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
        [SerializeField] private List<Move> moves;
        [SerializeField] private int startingHealth = 5;
        [SerializeField] private Animation anim;

        private int _health;
        
        public List<Move> GetAllMoves => moves;

        public bool Alive => _health > 0;

        [Button]
        public void ResetHealth()
        {
            _health = startingHealth;
        }

        public IEnumerator UseRandomMove(Entity target)
        {
            if (moves.Count == 0)
            {
                Debug.Log($"{name} had no moves available.");
                yield break;
            }
            
            int index = Random.Range(0, moves.Count); // range is inclusive & exclusive respectively
            Move move = moves[index];
            yield return StartCoroutine(UseMove(move, target));
        }
        public IEnumerator UseMove(Move move, Entity target)
        {
            Debug.Log($"{name} used move '{move.name}'.");

            foreach (Move.Action action in move.actions)
            {
                if (action.animation != null)
                {
                    yield return StartCoroutine(PlayAnimation(action.animation));
                }
                else
                {
                    yield return new WaitForSeconds(0.25f);
                }

                if (action.type == Move.ActionType.Damage)
                    target.DamageBy(action.amount);
                else if (action.type == Move.ActionType.Healing)
                    HealBy(action.amount);
            }
        }
        private IEnumerator PlayAnimation(AnimationClip clip)
        {
            anim.Play(clip.name);
            yield return new WaitForSeconds(clip.length);
        }
        
        private void HealBy(int amount)
        {
            _health += amount;
        }
        private void DamageBy(int amount)
        {
            _health -= amount;
        }
    }
}