using System;

namespace Combat
{
    [Serializable]
    public struct Move // "Move", the actual values of a move
    {
        public string name;
        public int damage;
        public int healing;
    }
}