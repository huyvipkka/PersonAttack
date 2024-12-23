using UnityEngine;

public class EnemyCheckTarget : MonoBehaviour {
    EnemyController controller;
    [SerializeField] LayerMask obstacleMask;
    private void Start() {
        controller = GetComponentInParent<EnemyController>();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.name == controller.target.name){
            Vector3 dir = (other.transform.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, other.transform.position);

            // Raycast kiểm tra vật cản
            controller.playerInSight = Physics2D.Raycast(transform.position, dir, distanceToPlayer, obstacleMask)
                                        ? false : true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (controller != null && controller.target != null && other.gameObject != null) {
        if (other.gameObject.name == controller.target.name) {
            controller.playerInSight = false;
        }
    }
    }
}