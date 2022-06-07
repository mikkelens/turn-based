using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [Serializable]
    public struct MoveData // "Move", the actual values of a move
    {
        public string name;
        public List<Action> actions;

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