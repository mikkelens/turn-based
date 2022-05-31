using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Management
{
    public enum FightState
    {
        PlayerTurn,
        EnemyWaiting,
        EnemyTurn,
        Ended,
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

        [ReadOnly] private FightState _state;
        
        [SerializeField] private Enemy enemy;
        
        private Player _player;
        
        private void Start()
        {
            _player = Player.Instance;
            if (_player == null) Debug.Log("Player missing?");
            
            _player.ResetHealth();
            enemy.ResetHealth();
        }

        [Button, EnableIf("@_state == FightState.PlayerTurn")]
        private void PlayerAttacks()
        {
            if (_state != FightState.PlayerTurn) return;
            _state = FightState.EnemyTurn;
            _player.Attack(enemy);
        }
        [Button, EnableIf("@_state == FightState.EnemyTurn")]
        private void EnemyAttacks()
        {
            if (_state != FightState.EnemyTurn) return;
            _state = FightState.PlayerTurn;
            enemy.Attack(_player);
        }

        public void WinBattle()
        {
            Debug.Log("Player won!");
            _state = FightState.Ended;
        }
        public void LoseBattle()
        {
            Debug.Log("Player lost.");
            _state = FightState.Ended;
        }
    }
}