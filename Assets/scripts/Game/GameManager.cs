using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance{
        get => _instance;
        private set => _instance = value;
    }
    public GameData data;
    private void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(gameObject);
            Debug.Log("Many instance in PlayerController");
        }
        DontDestroyOnLoad(gameObject);
    }
}