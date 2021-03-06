using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Structure
{
    [Serializable]
    public class FightDetails
    {
        public int buildIndex;
        public string fightName;
    }
    
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