using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresManager : MonoBehaviour {

    GameObject[] fires;
    int activeIndex;
    public delegate void OnActiveChanged(Transform obj);
    public event OnActiveChanged notifyActiveChange;
    void Start () {
        fires = GameObject.FindGameObjectsWithTag("Fire");
        QuickSort.QuickSortFunction(fires, 0, 1);

        ChangeActive(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeActive(int idx) {
        activeIndex = idx;
        print(fires[idx]);
        notifyActiveChange(fires[idx].transform);
    }
}
