using System.Data;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    private void Update()
    {
        if (target == null) return;
        transform.position = new Vector3(target.position.x, target.position.y, -10);

    }
}