using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject itemHp;
    public GameObject itemSpeed;
    public GameObject xu;
    public EnemyData data;
    public Rigidbody2D rigid;
    public GameObject target;
    Vector3 _dir;
    public Vector3 direction{
        get => _dir;
        set{
            _dir = value;
            RotateEnemy(_dir);
        }
    }
    public float speed;
    public bool checkObstacle;
    public bool playerInSight;


    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        direction = Random.onUnitSphere;
        speed = data.speed;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    
    
    private void RotateEnemy(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void UpdateVelo(Vector3 dir, float speed){
        this.speed = speed;
        this.direction = dir;
        rigid.velocity = this.direction.normalized * this.speed;
    }
    public void UpdateVelo(){
        rigid.velocity = this.direction.normalized * this.speed;
    }

    public void EnemyDie(float delay){
        StartCoroutine(DisableAfterSeconds(delay));
        EnemySpawner.Instance.currentEnemy--;

        if(Random.Range(0f, 1) <= data.RecoveryHpDropRate){
            PoolManager.Instance.GetFromPool(itemHp).transform.position
            = transform.position + (0.2f * Vector3.left);
        }
        if(Random.Range(0f, 1) <= data.BoostSpeedDropRate){
            PoolManager.Instance.GetFromPool(itemSpeed).transform.position
            = transform.position + (0.2f * Vector3.right);
        }
        if(Random.Range(0f, 1) <= data.xuDropRate){
            GameObject obj = PoolManager.Instance.GetFromPool(xu);
            obj.GetComponent<Xu>().value = data.xuValue * GameManager.Instance.data.doKho;
            obj.transform.position = transform.position + (0.2f * Vector3.up);
        }
    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}