using Sirenix.OdinInspector;
using UnityEngine;

namespace Navigation
{
    public class MapFight : MonoBehaviour
    {
        [SerializeField] private Fight fight;
        
        [Button]
        public void SelectThisLevel()
        {
            if (Application.isPlaying)
                GameManager.Instance.SelectFight(fight);
        }
    }
}