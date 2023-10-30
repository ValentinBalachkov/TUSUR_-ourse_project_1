using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CourseProject.UI
{
    public abstract class AbstractPanel : MonoBehaviour
    {
        [SerializeField] protected Button _actionButton;
        protected CompositeDisposable _disposable = new();
        protected PanelManager _panelManager;

        public void Init(PanelManager panelManager)
        {
            _panelManager = panelManager;
        }

        public abstract void Open();
        public abstract void Close();
    }
}