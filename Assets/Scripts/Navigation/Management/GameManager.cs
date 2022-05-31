﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation
{
    public enum GameState
    {
        MainMenu,
        MapScreen,
        Fight,
    }
    
    [Serializable]
    public class Fight
    {
        public int buildIndex;
        public string fightName;
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] private int mapSceneIndex;
        
        private GameState _state;
        private Fight _currentFight;

        private void Awake()
        {
            _state = GameState.MapScreen;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }

        public void SelectFight(Fight fight)
        {
            _currentFight = fight;
        }
        
        [Button, ShowIf("@_state == GameState.MapScreen"), DisableIf("@_currentFight == null")]  
        public void EnterFight()
        {
            if (_currentFight == null) return;
            if (_state == GameState.Fight) return;

            _state = GameState.Fight;
            LoadScene(_currentFight.buildIndex);
        }
        [Button, ShowIf("@_state == GameState.Fight")]
        private void ExitFight()
        {
            if (_state == GameState.MapScreen) return;
            
            _currentFight = null;
            _state = GameState.MapScreen;
            LoadScene(mapSceneIndex);
        }
        
        private void LoadScene(int buildIndex)
        {
            // todo: add transitions etc
            
            
            // load scene
            SceneManager.LoadScene(buildIndex);
            
            
            // todo: add detransition etc
        }
    }
}
