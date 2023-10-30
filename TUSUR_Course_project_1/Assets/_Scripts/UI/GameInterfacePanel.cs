using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CourseProject.UI
{
    public class GameInterfacePanel : AbstractPanel
    {
        [SerializeField] private Config _config;
        [SerializeField] private TMP_InputField _inputField;

        [SerializeField] private Button _backButton;
        [SerializeField] private GameObject _resultPanel;

        [SerializeField] private TMP_Text _resultText;
        
    
        private WordController _wordController;

        private void Start()
        {
            _wordController = new WordController(_config);
            _actionButton.OnClickAsObservable().Subscribe(_ => SetWord()).AddTo(_disposable);
            _backButton.OnClickAsObservable().Subscribe(_ =>
            {
                _panelManager.OpenPanel<MainMenuPanel>();
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        public override void Open()
        {
            _resultText.text = "";
            _inputField.text = "";
            gameObject.SetActive(true);
            _resultPanel.SetActive(false);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }

        private void SetWord()
        {
            _resultText.text = "";
            
            var words = _wordController.GetCorrectWords(_inputField.text);
            
            _resultPanel.SetActive(true);

            if (words.Count == 0)
            {
                _resultText.text = "Совпадений нет";
                return;
            }
            
            foreach (var word in words)
            {
                _resultText.text += word + " ";
                DebugLogger.SendMessage(word, Color.green);
            }
        }
    }
}
