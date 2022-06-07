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
        [SerializeField] private Animation anim;

        private int _health;
        
        public List<MoveSettings> GetAllMoveSettings => moveSettings;

        public bool Alive => _health > 0;

        [Button]
        public void ResetHealth()
        {
            _health = startingHealth;
        }

        public IEnumerator UseRandomMove(Entity target)
        {
            if (moveSettings.Count == 0)
            {
                Debug.Log($"{name} had no moves available.");
                yield break;
            }
            
            int index = Random.Range(0, moveSettings.Count); // range is inclusive & exclusive respectively
            MoveData moveData = moveSettings[index].MoveData;
            yield return StartCoroutine(UseMove(moveData, target));
        }
        public IEnumerator UseMove(MoveData moveData, Entity target)
        {
            Debug.Log($"{name} used move '{moveData.name}'.");

            foreach (MoveData.Action action in moveData.actions)
            {
                if (action.animation != null)
                {
                    yield return StartCoroutine(PlayAnimation(action.animation));
                }
                else
                {
                    yield return new WaitForSeconds(0.25f);
                }

                if (action.type == MoveData.ActionType.Damage)
                    target.DamageBy(action.amount);
                else if (action.type == MoveData.ActionType.Healing)
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