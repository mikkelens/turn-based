using System;
using System.Collections.Generic;
using Combat.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    [SelectionBase]
    public class FightMenu : MonoBehaviour
    {
        public static FightMenu Instance;
        private FightManager _fightManager;
        
        [SerializeField] private RectTransform generalMenu;
        [SerializeField, Required] private RectTransform moveMenu;


        private List<Button> _buttons;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void Start()
        {
            _fightManager = FightManager.Instance;
            if (_fightManager == null) Debug.Log("Fight manager missing!");
        }

        [Button]
        public void GenerateButtons()
        {
            DestroyAll(_buttons); // get rid of previous
            
            Player player = Player.Instance;
            if (player == null) return;
            _buttons = GenerateAll(player.GetAllMoveSettings); // get new
        }
        private void DestroyAll(List<Button> buttons)
        {
            foreach (Button button in buttons)
            {
                Destroy(button);
            }
        }
        private List<Button> GenerateAll(List<MoveSettings> moves)
        {
            List<Button> buttons = new();
            foreach (MoveSettings move in moves)
            {
                Button button = Instantiate(move.ButtonPrefab, generalMenu).GetComponent<Button>();
                button.onClick.AddListener(() => _fightManager.ChoosePlayerMove(move.Data));
                buttons.Add(button);
            }
            return buttons;
        }
    }
}
