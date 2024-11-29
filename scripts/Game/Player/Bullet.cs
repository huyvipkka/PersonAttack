using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            gameObject.SetActive(false);
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
        }
    }

    public void ResetNewBullet(Vector3 position)
    {
        transform.position = position;
        StartCoroutine(DisableAfterSeconds(5f));
    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

}
