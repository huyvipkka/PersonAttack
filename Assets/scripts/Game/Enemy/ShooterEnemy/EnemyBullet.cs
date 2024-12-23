using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    [SerializeField] private float _lifetime = 3f;
    [SerializeField] private float speed = 6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            GameEvent.onHpPlayerChange?.Invoke(healthController);
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

    public void ResetNewBullet(Vector3 position, Transform target)
    {
        transform.position = position;
        GetComponent<Rigidbody2D>().velocity = (target.position - position).normalized * speed;
        StartCoroutine(DisableAfterSeconds(_lifetime));

    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}