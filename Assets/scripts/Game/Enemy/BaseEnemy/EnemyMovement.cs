using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyController controller;
    
    private void Start() {
        controller = GetComponent<EnemyController>();
        StartCoroutine(ChangeDirEachTime(5));
    }

    private void Update() {
        if(controller.checkObstacle)
            controller.UpdateVelo(Random.insideUnitCircle.normalized, controller.speed);

        if(controller.playerInSight){
            Vector3 dir = controller.target.transform.position - transform.position;
            controller.UpdateVelo(dir, controller.data.speedBoost);
        }
        else{
            controller.speed = controller.data.speed;
            controller.UpdateVelo();
        }
    }

    private IEnumerator ChangeDirEachTime(float seconds){
        while(gameObject.activeSelf){
            Vector3 newDir = Random.insideUnitCircle.normalized;
            controller.UpdateVelo(newDir, controller.speed);
            yield return new WaitForSeconds(seconds);
        }
    }
}
