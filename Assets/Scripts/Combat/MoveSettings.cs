using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(menuName = "Combat/Move", fileName = "Unnamed Move")]
    public class MoveSettings : ScriptableObject
    {
        [SerializeField] private string moveName = "Unnamed move";
        [SerializeField] private int moveDamage = 1;
        [SerializeField] private int moveHealing = 0;
        
        [SerializeField] private GameObject buttonPrefab;
        public GameObject ButtonPrefab => buttonPrefab;

        public Move Data => new()
        {
            name = moveName,
            damage = moveDamage,
            healing = moveHealing
        };
    }
}