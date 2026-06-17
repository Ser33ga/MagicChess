using UnityEngine;

public class UnitConfigProxy : MonoBehaviour
{
    [SerializeField] private ScriptableObject configAsset;

    public IUnitConfig config => (IUnitConfig)configAsset;
}
