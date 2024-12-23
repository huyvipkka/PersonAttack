using System.Collections;
using UnityEngine;

public class Xu : MonoBehaviour, ICollectable
{
    public int value;

    private void Start()
    {
        StartCoroutine(DisableAfterSeconds(5));
    }
    public void Collect(GameObject collector)
    {
        GameManager.Instance.data.xu += value;
        gameObject.SetActive(false);
        Debug.Log($"Xu: {GameManager.Instance.data.xu}");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }
    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}