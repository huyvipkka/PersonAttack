using System.Collections;
using UnityEngine;

public class BoostSpeed : MonoBehaviour, ICollectable
{
    [SerializeField] ItemBoostSpeedData data;
    [SerializeField] float boost_percent;
    [SerializeField] float time;
    private void Start()
    {
        RefreshData();
        StartCoroutine(DisableAfterSeconds(5));
    }

    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent<PlayerMoving>(out PlayerMoving move))
        {
            move.BoostSpeed(boost_percent, time);
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
        boost_percent = data.boost_percent;
        time = data.time;
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}