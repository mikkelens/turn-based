using System.Collections.Generic;
using Combat.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    [SelectionBase]
    public class FightMenuUI : MonoBehaviour
    {
        public static FightMenuUI Instance;
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
                Destroy(button.gameObject); // remove previous buttons
            }
            _buttons.Clear();

            Player player = Player.Instance;
            if (player == null) return;

            List<Move> moveSettings = player.GetAllMoves;
            for (int i = 0; i < moveSettings.Count; i++)
            {
                Move move = moveSettings[i];

                RectTransform parent = i % 2 == 0 ? topRow : bottomRow;
                Button button = Instantiate(move.ButtonPrefab, parent); // generate new buttons
                button.onClick.AddListener(
                    delegate
                    {
                        FightManager.Instance.ChoosePlayerMove(move);
                    });
                _buttons.Add(button);
                
                Text title = button.GetComponentInChildren<Text>();
                if (title != null)
                    title.text = move.name;
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
