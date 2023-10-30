using CourseProject.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameInterfacePanel : AbstractPanel
{
    [SerializeField] private Config _config;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _actionButton;
    
    private WordController _wordController;
    private CompositeDisposable _disposable = new();

    private void Start()
    {
        _wordController = new WordController(_config);
        _actionButton.OnClickAsObservable().Subscribe(_ => SetWord()).AddTo(_disposable);
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }

    public override void Open()
    {
        _inputField.text = "";
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    private void SetWord()
    {
        var words = _wordController.GetCorrectWords(_inputField.text);
       
        foreach (var word in words)
        {
            DebugLogger.SendMessage(word, Color.green);
        }
    }
}
