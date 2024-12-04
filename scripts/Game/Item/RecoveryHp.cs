using System.Collections;
using UnityEngine;

public class ItemRecoveryHp : MonoBehaviour, ICollectable
{
    [SerializeField] int HpRecovery;
    [SerializeField] ItemRecoveryHpData itemData;
    private void Start()
    {
        RefreshData();
    }
    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent<HealthController>(out HealthController health))
        {
            health.AddHealth(HpRecovery);
            GameEvent.onHpPlayerChange?.Invoke(health);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }
    public void RefreshData()
    {
        HpRecovery = itemData.HpRecovery;
        StartCoroutine(DisableAfterSeconds(5));
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}