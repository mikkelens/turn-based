using System;
using System.Collections;
using System.Collections.Generic;
using Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Combat
{
    [SelectionBase]
    public class Entity : MonoBehaviour
    {
        [Header("Stats")]
        
        [Note("Moves are the actions that the entity can take.")]
        [SerializeField] private List<Move> moves;

        [HorizontalLine(Thickness = 2f, Padding = 12f)]
        
        [SerializeField] private int startingHealth = 5;

        private Animation _anim;
        private int _health;

        private void Awake()
        {
            _anim = GetComponent<Animation>();
        }

        // getters
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
            _anim.Play(clip.name);
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