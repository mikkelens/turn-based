using System.Collections.Generic;
using Gameplay.Management;
using UnityEngine;

namespace Gameplay
{
    public class Player : Entity
    {
        public static Player Instance; // because player moves from scene to scene

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Debug.Log("Two players in scene!");
        }

        #region Entity specifications/overrides
        protected override void Die()
        {
            base.Die();
            FightManager.Instance.LoseBattle();
        }
        #endregion
    }
}