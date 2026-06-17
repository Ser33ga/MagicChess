using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerField : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    public void UpdateTimer(float newValue){
        timer.text=newValue.ToString();
    }
}
