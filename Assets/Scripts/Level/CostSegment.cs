using TMPro;
using UnityEngine;

public class CostSegment : MonoBehaviour
{
    public FloorSegment segment;
    private Camera camera;
    [SerializeField] GameObject costObj;
    [SerializeField] TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        segment=GetComponent<FloorSegment>();
        segment.SetUnit+=OnUI;
        segment.GetUnit+=OffUI;
    }
    public void Init(Camera cam)
    {
        camera=cam;
    }
    public void OnUI()
    {
        costObj.SetActive(true);
        text.text=segment.unit.GetComponent<UnitData>().cost.ToString();
    }
    public void OffUI()
    {
        costObj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        segment.SetUnit-=OnUI;
        segment.GetUnit-=OffUI;
    }
}
