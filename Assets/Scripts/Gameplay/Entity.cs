using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay
{
    public class Entity : MonoBehaviour
    {
        // stats
        [SerializeField] protected int startingHealth = 5;
        [SerializeField] protected int attackDamage = 2;
        private int _currentHealth;
        
        [SerializeField] private Animator animator;

        public void Attack(Entity target)
        {
            PlayAttackAnimation();
            target.TakeDamage(attackDamage);
        }
        private void PlayAttackAnimation() { }

        private void TakeDamage(int amount)
        {
            Debug.Log($"Entity {name} was damaged by {amount.ToString()}");
            PlayDamageAnimation();
            _currentHealth -= amount;
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
            PlayDeathAnimation();
            Debug.Log($"Entity {name} was killed.");
        }
        private void PlayDeathAnimation() { }
    }
}