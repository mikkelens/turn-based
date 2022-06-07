using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    [CreateAssetMenu(menuName = "Combat/Move", fileName = "Unnamed Move")]
    public class Move : ScriptableObject
    {
        public Button ButtonPrefab => buttonPrefab;
        [SerializeField] private Button buttonPrefab;
        [SerializeField] public List<Action> actions = new()
        {
            new Action
            {
                type = ActionType.Damage,
                amount = 1,
                animation = null,
            }
        };

        // sub-datatypes
        [Serializable]
        public struct Action
        {
            public ActionType type;
            public int amount;
            public AnimationClip animation;
        }
        [Serializable]
        public enum ActionType
        {
            Damage,
            Healing
        }
    }
}