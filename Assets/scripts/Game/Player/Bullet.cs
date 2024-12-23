using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime = 3f; // Thời gian sống của đạn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<EnemyHealController>()
            .TakeDamage(PlayerController.Instance.data.atk);
        }
        if (collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(DisableAfterSeconds(5f));
    }

    public void ResetNewBullet(Vector3 position)
    {
        transform.position = position;
        StartCoroutine(DisableAfterSeconds(_lifetime));
    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
