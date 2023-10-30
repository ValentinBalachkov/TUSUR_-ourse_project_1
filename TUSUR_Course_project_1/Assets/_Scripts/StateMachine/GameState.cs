using UnityEngine;

namespace StateMachine
{
    public class GameState : BaseState
    {
        private PanelManager _panelManager;
        public GameState(GameStateMachine gameStateMachine, PanelManager panelManager) : base(gameStateMachine)
        {
            _panelManager = panelManager;
        }

        public override void Enter()
        {
            _panelManager.OpenPanel<GameInterfacePanel>();
            DebugLogger.SendMessage("Enter game state", Color.green);
        }

        public override void Exit()
        {
            DebugLogger.SendMessage("Exit game state", Color.red);
        }
    }
}