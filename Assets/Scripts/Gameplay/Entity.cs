using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay
{
    [SelectionBase]
    public class Entity : MonoBehaviour
    {
        // stats
        [SerializeField] private int startingHealth = 5;
        [SerializeField] private int attackDamage = 2;
        [SerializeField] private Animator animator;
        private int _currentHealth;

        [Button]
        public void ResetHealth()
        {
            Debug.Log($"{name} health reset to {startingHealth.ToString()}, was {_currentHealth.ToString()}");
            _currentHealth = startingHealth;
        }
        
        public void Attack(Entity target)
        {
            PlayAttackAnimation();
            target.TakeDamage(attackDamage);
        }
        private void PlayAttackAnimation() { }

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