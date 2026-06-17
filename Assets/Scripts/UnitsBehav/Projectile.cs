using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject aim;
    public float speed;
    public UnitData data;

    // Update is called once per frame
    void Update()
    {
        if (aim != null)
        {
            transform.LookAt(aim.transform);
            transform.position+=transform.forward*speed*Time.deltaTime;
            if (Vector3.Distance(aim.transform.position, transform.position) < 0.1f)
            {
                data.projManager.RemoveProjectile(gameObject);
            }
        } else
        {
            if (data == null)
                {
                    Destroy(gameObject);
                }
            else
                {
                    data.projManager.RemoveProjectile(gameObject);
                }
        }
    }
}
