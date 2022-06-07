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
        
        [SerializeField, Required] private RectTransform moveMenu;
        [SerializeField, Required] private RectTransform topRow;
        [SerializeField, Required] private RectTransform bottomRow;


        private List<Button> _buttons = new();

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
        
        private void RegenerateButtons()
        {
            foreach (Button button in _buttons)
            {
                _buttons.Remove(button);
                Destroy(button.gameObject); // remove previous buttons
            }
            
            Player player = Player.Instance;
            if (player == null) return;

            List<MoveSettings> moveSettings = player.GetAllMoveSettings;
            for (int i = 0; i < moveSettings.Count; i++)
            {
                MoveSettings moveSetting = moveSettings[i];
                MoveData moveData = moveSetting.MoveData; // pull data out because of the way callback uses it
                
                RectTransform parent = i % 2 == 0 ? topRow : bottomRow;
                Button button = Instantiate(moveSetting.ButtonPrefab, parent); // generate new buttons
                button.onClick.AddListener(() => _fightManager.ChoosePlayerMove(moveData));
                _buttons.Add(button);
                
                Text title = button.GetComponentInChildren<Text>();
                if (title != null)
                    title.text = moveData.name;
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(moveMenu); // force update/refresh
        }
        
        public void SetMenuVisible(bool show)
        {
            if (show && Application.isPlaying) RegenerateButtons();
            moveMenu.gameObject.SetActive(show);
        }
        private bool ActiveMenu => moveMenu.gameObject.activeSelf;
        // neat little inspector buttons
        [ButtonGroup("toggle"), DisableIf("ActiveMenu")] private void ShowMenu() => SetMenuVisible(true);
        [ButtonGroup("toggle"), EnableIf("ActiveMenu")] private void HideMenu() => SetMenuVisible(false);
    }
}
