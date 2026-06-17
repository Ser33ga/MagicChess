using TMPro;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    [SerializeField]private SpriteRenderer hpBar;
    [SerializeField]private TMP_Text levelCount;
    public UnitData data;
    void Start()
    {
        data=GetComponent<UnitData>();
        data.hpChanged+=RefreshHpBar;
        RefreshHpBar();
        levelCount.text=data.level.ToString();
    }
    void RefreshHpBar()
    {
        hpBar.size=new Vector2(Mathf.Clamp01((float)data.health/data.startHealth), hpBar.size.y);
    }
    void OnDestroy()
    {
        data.hpChanged-=RefreshHpBar;
    }
}
