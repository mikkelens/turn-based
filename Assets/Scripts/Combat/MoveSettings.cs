using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    [CreateAssetMenu(menuName = "Combat/Move", fileName = "Unnamed Move")]
    public class MoveSettings : ScriptableObject
    {
        public Button ButtonPrefab => buttonPrefab;
        [SerializeField] private Button buttonPrefab;

        public MoveData MoveData => moveData;
        [SerializeField] private MoveData moveData = new()
        {
            name = "Unnamed move",
            actions = new()
            {
                new MoveData.Action()
                {
                    type = MoveData.ActionType.Damage,
                    amount = 1,
                    animation = null,
                }
            }
        };
    }
}