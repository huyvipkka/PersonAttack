using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private readonly Dictionary<GameObject, Pool> dicPools = new();
    private readonly Dictionary<string, Transform> parents = new();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple PoolManager instances detected!");
            Destroy(gameObject);
        }
    }


    public GameObject GetFromPool(GameObject obj)
    {
        if (!dicPools.ContainsKey(obj))
        {
            dicPools.Add(obj, new Pool(obj));
        }
        GameObject newObj = dicPools[obj].Get();
        Transform parentTransform = Getparent(obj.name);
        newObj.transform.SetParent(parentTransform);
        return newObj;
    }

    private Transform Getparent(string objectName)
    {
        if (!parents.ContainsKey(objectName))
        {
            GameObject parentObj = new(objectName);
            parentObj.transform.SetParent(transform);
            parents[objectName] = parentObj.transform;
        }
        return parents[objectName];
    }
}