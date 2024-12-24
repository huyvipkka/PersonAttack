using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public class StatsUpgradeData : ScriptableObject
{
    public int StatsEachLv;
    public int currentLv;
    public int maxLv;
    public int baseXu;
    public float XuBonusPercent;
}