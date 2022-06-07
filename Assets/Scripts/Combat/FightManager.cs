using System.Collections;
using Combat.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat
{
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
        
        [SerializeField] private Enemy enemy;
        private Player _player;
        private MoveData? _chosenMove;
        
        private void Start()
        {
            _player = Player.Instance;
            if (_player == null) Debug.Log("Player missing?");
            
            _player.ResetHealth();
            enemy.ResetHealth();

            StartCoroutine(FightRoutine());
        }
        
        public void ChoosePlayerMove(MoveSettings move)
        {
            _chosenMove = move.MoveData;
        }

        private enum FightState
        {
            Fighting,
            Win,
            Loss,
        }
        private IEnumerator FightRoutine()
        {
            FightState state = FightState.Fighting;
            while (state == FightState.Fighting)
            {
                // player
                yield return StartCoroutine(PlayerTurn()); // wait for player turn to finish
                state = UpdatedState();
                if (state != FightState.Fighting) break;
                
                // enemy
                yield return StartCoroutine(EnemyTurn()); // wait for enemy turn to finish
                state = UpdatedState();
            }
            // game ended
            if (state == FightState.Win) WinBattle();
            if (state == FightState.Loss) LoseBattle();
        }
        
        private IEnumerator PlayerTurn()
        {
            FightMenu.Instance.SetMenuVisible(true);

            _chosenMove = null;
            yield return new WaitUntil(() => _chosenMove != null); // wait for player to choose move (happens through UI)
            MoveData move = _chosenMove!.Value;
            
            FightMenu.Instance.SetMenuVisible(false);
            yield return StartCoroutine(_player.UseMove(move, enemy)); // wait for move to finish
        }
        private IEnumerator EnemyTurn()
        {
            yield return StartCoroutine(enemy.UseRandomMove(_player)); // wait for random move to finish
        }
        
        private FightState UpdatedState()
        {
            // health checks
            if (_player.Alive == false) return FightState.Loss;
            if (enemy.Alive == false) return FightState.Win;
                
            return FightState.Fighting;
        }
        

        // generic end display
        private void WinBattle()
        {
            Debug.Log("Player won!");
        }
        private void LoseBattle()
        {
            Debug.Log("Player lost.");
        }
        private void FledBattle()
        {
            Debug.Log("Player fled.");
        }
        
    }
}