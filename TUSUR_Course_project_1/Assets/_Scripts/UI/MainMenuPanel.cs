using StateMachine;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CourseProject.UI
{
    public class MainMenuPanel : AbstractPanel
    {
        [SerializeField] private Button _aboutButton;
        [SerializeField] private Button _referenceButton;
        
        
        private GameStateMachine _gameStateMachine;

        private void Start()
        {
            _actionButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(_disposable);
            
            _aboutButton.OnClickAsObservable().Subscribe(_ =>
            {
                _panelManager.OpenPanel<AboutPanel>();
            }).AddTo(_disposable);
            
            _referenceButton.OnClickAsObservable().Subscribe(_ =>
            {
                _panelManager.OpenPanel<ReferencePanel>();
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        public void Init(GameStateMachine gameStateMachine)
        {
            if (_gameStateMachine != null)
            {
                return;
            }
            _gameStateMachine = gameStateMachine;
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }

        private void StartGame()
        {
            _gameStateMachine.ChangeState<GameState>();
        }
        
    }
}
