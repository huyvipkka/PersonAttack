using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    [SerializeField] EnemyData data;
    [SerializeField] GameObject itemHp;
    [SerializeField] GameObject itemSpeed;

    [System.Obsolete]
    public void DestroyEnemy(float delay)
    {
        StartCoroutine(DisableAfterSeconds(delay));
        if (Random.Range(0, 1f) <= data.RecoveryHpDropRate)
        {
            PoolManager.Instance.GetFromPool(itemHp).transform.position = transform.position + (0.2f * Vector3.left);
        }
        if (Random.Range(0, 1f) <= data.BoostSpeedDropRate)
        {
            PoolManager.Instance.GetFromPool(itemSpeed).transform.position = transform.position + (0.2f * Vector3.right);
        }
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
