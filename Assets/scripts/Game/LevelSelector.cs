using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider slider;
    private void OnEnable() {
        levelText.SetText($"Level Select: {GameManager.Instance.data.doKho}");
        slider.value = GameManager.Instance.data.doKho;
    }

    public void UpdateDoKho(){
        GameManager.Instance.data.doKho = Mathf.RoundToInt(slider.value);
        levelText.SetText($"Level Select: {GameManager.Instance.data.doKho}");
    }
}
