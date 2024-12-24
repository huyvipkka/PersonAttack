using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyController controller;
    float timer;
    private void Start() {
        controller = GetComponentInParent<EnemyController>();
        timer = controller.data.cooldownAttack;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(timer < controller.data.cooldownAttack) timer += Time.deltaTime;
        else if (collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(controller.data.atk * GameManager.Instance.data.doKho);
            GameEvent.onHpPlayerChange?.Invoke(healthController);
            timer = 0;
        }
    }
}
