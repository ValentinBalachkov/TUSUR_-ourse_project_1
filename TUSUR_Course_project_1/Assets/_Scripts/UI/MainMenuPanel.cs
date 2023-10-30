using CourseProject.UI;

public class MainMenuPanel : AbstractPanel
{

    public override void Open()
    {
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }
}
