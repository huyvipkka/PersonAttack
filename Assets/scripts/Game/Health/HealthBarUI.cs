using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;
    private void Start()
    {
        GameEvent.onHpPlayerChange += health => UpdateHealthBar(health);
    }
    public void UpdateHealthBar(HealthController healthController)
    {
        _healthBarForegroundImage.fillAmount = healthController.GetPercentHp();
    }
}