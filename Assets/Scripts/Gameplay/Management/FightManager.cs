using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Management
{
    public enum FightState
    {
        PlayerTurn,
        EnemyTurn,
    }
    public enum Actions
    {
        // Attack,
        // Defend,
        // Item,
        // Flee,
    }
    
    // not a persistent manager, only lives in fight / scene
    public class FightManager : MonoBehaviour
    {
        public static FightManager Instance; // because there will only be one per scene

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Debug.Log("Two fightmanagers in scene!");
        }

        private FightState _state;
        
        [SerializeField] private Enemy enemy;
        
        private Player _player;
        
        private void Start()
        {
            _player = Player.Instance;
            if (_player == null) Debug.Log("Player missing?");
        }

        [Button, EnableIf("@_state == FightState.PlayerTurn")]
        private void PlayerAttacks()
        {
            if (_state != FightState.PlayerTurn) return;
            _player.Attack(enemy);
            _state = FightState.EnemyTurn;
        }
        [Button, EnableIf("@_state == FightState.EnemyTurn")]
        private void EnemyAttacks()
        {
            if (_state != FightState.EnemyTurn) return;
            enemy.Attack(_player);
            _state = FightState.PlayerTurn;
        }

        public void WinBattle()
        {
            Debug.Log("Player won!");
        }
        public void LoseBattle()
        {
            Debug.Log("Player lost.");
        }
    }
}