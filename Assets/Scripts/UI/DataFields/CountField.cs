using TMPro;
using UnityEngine;

public class CountField : MonoBehaviour
{
    [SerializeField] TMP_Text redCount;
    [SerializeField] TMP_Text blueCount;
    public void UpdateRedCount(int newValue){
        redCount.text=newValue.ToString();
    }
    public void UpdateBlueCount(int newValue){
        blueCount.text=newValue.ToString();
    }
}
