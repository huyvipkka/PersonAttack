using UnityEngine;

public class ReturnPool : MonoBehaviour
{
    public Pool pool;
    private void OnDisable()
    {
        pool.AddToPool(this.gameObject);
    }
}