using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private PanelManager _panelManager;
        
        private BaseState _currentState;

        private MenuState _menuState;
        private GameState _gameState;

        private List<BaseState> _states = new();
        

        private void Awake()
        {
            _menuState = new MenuState(this, _panelManager);
            _gameState = new GameState(this, _panelManager);

            _states.Add(_menuState);
            _states.Add(_gameState);
        }

        private void Start()
        {
            ChangeState<MenuState>();
        }

        public void ChangeState<T>() where T : BaseState
        {
            _currentState?.Exit();
            _currentState = _states.FirstOrDefault(x => x is T);
            _currentState.Enter();
        }
    }
}