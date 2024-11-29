using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<GameObject> stack = new();
    private readonly GameObject baseObj;
    private GameObject tmp;
    public Pool(GameObject baseObj)
    {
        this.baseObj = baseObj;
    }

    public GameObject Get()
    {
        if (stack.Count > 0)
        {
            tmp = stack.Pop();
            tmp.SetActive(true);
            return tmp;
        }

        tmp = GameObject.Instantiate(baseObj);
        tmp.AddComponent<ReturnPool>().pool = this;
        return tmp;
    }

    public void AddToPool(GameObject obj)
    {
        stack.Push(obj);
    }

}