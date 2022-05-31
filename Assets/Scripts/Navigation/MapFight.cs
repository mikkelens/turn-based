using Sirenix.OdinInspector;
using UnityEngine;

namespace Navigation
{
    public class MapFight : MonoBehaviour
    {
        [SerializeField] private FightDetails fightDetails;
        
        [Button]
        public void SelectThisLevel()
        {
            if (Application.isPlaying)
                GameManager.Instance.SelectFight(fightDetails);
        }
    }
}