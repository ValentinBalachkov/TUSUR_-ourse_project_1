using UniRx;

namespace CourseProject.UI
{
    public class AboutPanel : AbstractPanel
    {
        private void Start()
        {
            _actionButton.OnClickAsObservable().Subscribe(_ => SetMainMenu()).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        public override void Open()
        {
           gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }

        private void SetMainMenu()
        {
            _panelManager.OpenPanel<MainMenuPanel>();
        }
    }
}
