using UnityEngine;

namespace StateMachine
{
    public class MenuState : BaseState
    {
        private PanelManager _panelManager;
        public MenuState(GameStateMachine gameStateMachine, PanelManager panelManager) : base(gameStateMachine)
        {
            _panelManager = panelManager;
        }

        public override void Enter()
        {
            _panelManager.OpenPanel<MainMenuPanel>();
            DebugLogger.SendMessage("Enter menu state", Color.green);
        }

        public override void Exit()
        {
            DebugLogger.SendMessage("Exit menu state", Color.red);
        }
    }
}