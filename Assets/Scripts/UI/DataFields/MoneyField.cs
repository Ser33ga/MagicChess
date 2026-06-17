using UnityEngine;
using TMPro;
public class MoneyField : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    public void UpdateMoney(int newValue){
        moneyText.text=newValue.ToString();
    }
}
