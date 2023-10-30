using CourseProject.UI;
using UnityEngine;

namespace StateMachine
{
    public class MenuState : BaseState
    {
        private PanelManager _panelManager;
        private GameStateMachine _gameStateMachine;
        public MenuState(GameStateMachine gameStateMachine, PanelManager panelManager) : base(gameStateMachine)
        {
            _panelManager = panelManager;
            _gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            _panelManager.OpenPanel<MainMenuPanel>();
            _panelManager.GetPanel<MainMenuPanel>().Init(_gameStateMachine);
            DebugLogger.SendMessage("Enter menu state", Color.green);
        }

        public override void Exit()
        {
            DebugLogger.SendMessage("Exit menu state", Color.red);
        }
    }
}