using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        StartCoroutine(DisableAfterSeconds(delay));
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
