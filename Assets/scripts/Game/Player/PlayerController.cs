using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public PlayerData data;
    public float speed;
    public Rigidbody2D rb;
    [SerializeField] TextMeshProUGUI HpText;
    [SerializeField] TextMeshProUGUI AtkText;
    [SerializeField] TextMeshProUGUI CoinText;
    HealthController health;
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
        health = GetComponent<HealthController>();
    }

    private void Start() {
        UpdateCoinText();
        UpdateAtkText();
        UpdateHpText(health);

        GameEvent.onCoinChange += UpdateCoinText;
        GameEvent.onHpPlayerChange += h => UpdateHpText(h);
    }

    private void OnDestroy() {
        GameEvent.onCoinChange -= UpdateCoinText;
    }
    void UpdateCoinText(){
        CoinText.SetText($"Coins: {GameManager.Instance.data.xu}");
    }

    void UpdateAtkText(){
        AtkText.SetText($"Atk: {data.atk}");
    }

    void UpdateHpText(HealthController health){
        HpText.SetText($"{health._currentHealth} / {health._maximumHealth}");
    }
}