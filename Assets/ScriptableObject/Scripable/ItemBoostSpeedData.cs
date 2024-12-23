using UnityEngine;

[CreateAssetMenu(fileName = "BoostSpeedData", menuName = "Scriptable Objects/Boost Speed")]
public class ItemBoostSpeedData : ScriptableObject
{
    public float boost_percent;
    public float time;
}