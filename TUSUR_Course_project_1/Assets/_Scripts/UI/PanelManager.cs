using System.Collections.Generic;
using System.Linq;
using CourseProject.UI;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private Transform _content;

    [SerializeField] private AbstractPanel[] _panels;

    private AbstractPanel _currentPanel;

    private List<AbstractPanel> _panelsOnScene = new();

    public void OpenPanel<T>() where T : AbstractPanel
    {
        if (_currentPanel != null)
        {
            _currentPanel.Close();
        }
        var panelOnScene = _panelsOnScene.FirstOrDefault(x => x is T);

        if (panelOnScene != null)
        {
            _currentPanel = panelOnScene;
            _currentPanel.Open();
        }
        else
        {
            var panelType = _panels.FirstOrDefault(x => x is T);
            var panel = Instantiate(panelType, _content);
            _panelsOnScene.Add(panel);
            _currentPanel = panel;
            _currentPanel.Open();
        }
    }
    
    
}
