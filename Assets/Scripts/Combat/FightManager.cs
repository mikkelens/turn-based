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

        //todo: make player able to select (show move info on screen), also: make moves in the editor
        
        [Button, EnableIf("@_state == FightState.PlayerTurn")]
        private void RandomPlayerMove()
        {
            if (_state != FightState.PlayerTurn) return;
            _state = FightState.EnemyTurn;
            _player.SelectRandomMove();
            _player.UseMove();
        }
        
        [Button, EnableIf("@_state == FightState.EnemyTurn")]
        private void RandomEnemyMove()
        {
            if (_state != FightState.EnemyTurn) return;
            _state = FightState.PlayerTurn;
            enemy.SelectRandomMove();
            enemy.UseMove();
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