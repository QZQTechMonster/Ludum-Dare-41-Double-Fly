using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForceBase : MonoBehaviour
{
    protected GameObject[] obj;
    protected int activeIndex;

    protected Transform player;

    public delegate void OnActiveChanged(Transform obj);
    public event OnActiveChanged notifyActiveChange;

    protected void StartWithTag(string tag)
    {
        obj = GameObject.FindGameObjectsWithTag(tag);
        QuickSort.QuickSortFunction(obj, 0, obj.Length-1);

        ChangeActive(0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateActive();
    }

    protected void ChangeActive(int idx)
    {
        activeIndex = idx;
        notifyActiveChange(obj[idx].transform);
    }

    protected float GetSqrDistanceToPlayer(int index)
    {
        return (player.position - obj[index].transform.position).sqrMagnitude;
    }
    protected abstract void UpdateActive();
}
