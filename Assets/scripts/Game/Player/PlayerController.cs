using UnityEngine;

public class PlayerController : MonoBehaviour {
    public PlayerData data;
    public float speed;
    public Rigidbody2D rb;
    
    private static PlayerController _instance;
    public static PlayerController Instance{
        get => _instance;
        private set => _instance = value;
    }
    private void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(gameObject);
            Debug.Log("Many instance in PlayerController");
        }

        rb = GetComponent<Rigidbody2D>();
        speed = data.speed;
    }
}