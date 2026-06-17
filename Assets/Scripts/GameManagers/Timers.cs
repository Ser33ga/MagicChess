using UnityEngine;
using System.Collections;
using VContainer;
using System.Threading;
public class Timers : MonoBehaviour
{
    [Inject] GameData data;
    public bool isBattleReady;
    public float outputChoosingTimer;
    public IEnumerator ChoosingCount()
    {
        isBattleReady= false;
        float timer=0f;
        while (timer < data.ChoosingTime)
        {
            timer += Time.deltaTime;
            if (data.ChoosingTime - timer > 0)
            {
               outputChoosingTimer=data.ChoosingTime-timer; 
            }else
            {
                outputChoosingTimer=0f;
            }   
            yield return null;
        }
        isBattleReady= true;
    }
}
