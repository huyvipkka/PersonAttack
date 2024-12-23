using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _timeBetweenShots;
    private float timer;
    private EnemyController controller;
    
    private void Start() {
        controller = GetComponent<EnemyController>();
        _timeBetweenShots = controller.data.cooldownAttack;
        timer = _timeBetweenShots;
    }
    private void Update() {
        if(timer < _timeBetweenShots) 
            timer += Time.deltaTime;
        else if(controller.playerInSight){
            FireBullet();
            timer = 0;
        }
    }

    private void FireBullet(){
        GameObject bullet = PoolManager.Instance.GetFromPool(_bulletPrefab);
        bullet.GetComponent<EnemyBullet>()
        .ResetNewBullet(transform.position, controller.target.transform);
    }

    
}