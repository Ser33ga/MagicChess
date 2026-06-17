using System;
using UnityEngine;

public class MoneyManager
{
    public int blueMoney=10;
    public int redMoney=10;
    public event Action MoneySpended;
    public bool SpendMoney(int amount, bool isBlue)
    {
        if (isBlue)
        {
            if (blueMoney - amount >= 0)
            {
                blueMoney-=amount;
                MoneySpended?.Invoke();
                return true;
            } else
            {
                return false;
            }
        }
        else 
        {
            if (redMoney - amount >= 0)
            {
                redMoney-=amount;
                return true;
            } else
            {
                return false;
            }
        }
    }
    public void GetMoney(int amount, bool isBlue)
    {
        if (isBlue)
        {
            blueMoney+=amount;
            MoneySpended?.Invoke();
        }else
        {
            redMoney+=amount;
        }
    }
}
