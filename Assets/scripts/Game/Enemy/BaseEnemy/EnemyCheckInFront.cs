using UnityEngine;


public class EnemyCheckInFront : MonoBehaviour {
    EnemyController controller;
    private void Start() {
        controller = GetComponentInParent<EnemyController>();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall"))
            controller.checkObstacle = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        controller.checkObstacle = false;
    }
}




