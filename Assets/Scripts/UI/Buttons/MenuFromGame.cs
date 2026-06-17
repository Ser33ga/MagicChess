using UnityEngine;
using UnityEngine.UI;
public class MenuFromGame : MonoBehaviour
{
    public UIController controller;
    private Button btn;
    void Start()
    {
        btn=GetComponent<Button>();
        btn.onClick.AddListener(Clicked);
    }
    public void Clicked()
    {
        controller.OpenMenu();
    }
}