using System.Collections.Generic;
using Gameplay.Management;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay
{
    [SelectionBase]
    public class Entity : MonoBehaviour
    {
        // stats
        [SerializeField] private int startingHealth = 5;
        [SerializeField] private List<CombatMove> attacks;
        [SerializeField] private Animator animator;
        
        private int _currentHealth;
        private CombatMove _selectedCombatMove;
        private Entity _targetedEntity;
        
        [Button]
        public void ResetHealth()
        {
            Debug.Log($"{name} health reset to {startingHealth.ToString()}, was {_currentHealth.ToString()}");
            _currentHealth = startingHealth;
        }

        public void SelectEntity(Entity target)
        {
            _targetedEntity = target;
        }
        
        public void SelectRandomMove()
        {
            _selectedCombatMove = attacks[Random.Range(0, attacks.Count - 1)];
        }
        public void SelectMove(CombatMove combatMove)
        {
            _selectedCombatMove = combatMove;
            UseMove();
        }

        public void UseMove()
        {
            PlayMoveAnimation();
            _targetedEntity.TakeDamage(_selectedCombatMove.damage);
             Heal(_selectedCombatMove.healing);
        }
        private void PlayMoveAnimation() { }

        private void Heal(int amount)
        {
            _currentHealth += amount;
        }
        private void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            PlayDamageAnimation();
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
        private void PlayDamageAnimation()
        {
            animator.SetTrigger("DamageTrigger");
        }
        
        protected virtual void Die()
        {
            Debug.Log($"{name} was killed.");
            PlayDeathAnimation();
        }
        private void PlayDeathAnimation()
        {
            Destroy(gameObject);
        }
    }
}