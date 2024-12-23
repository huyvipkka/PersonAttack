using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class PlayerData : ScriptableObject
{
    public int hpMax;
    public float speed;
    public int atk;
}