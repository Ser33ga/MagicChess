using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    protected static T _Instance;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance=FindAnyObjectByType<T>();
            }
            if (_Instance == null)
            {
                var singleton=new GameObject();
                singleton.name=typeof(T).Name;
                _Instance=singleton.AddComponent<T>();
            }
            return _Instance;
        }
    }
    protected virtual void Awake()
    {
        _Instance = this as T;
    }
}
