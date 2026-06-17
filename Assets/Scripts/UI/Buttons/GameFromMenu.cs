using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameFromMenu : MonoBehaviour
{
    public MenuEventBus eventBus;
    private Button btn;
    void Start()
    {
        btn=GetComponent<Button>();
        btn.onClick.AddListener(Clicked);
    }
    public void Clicked()
    {
        eventBus._GameFromMenu();
    }
}
