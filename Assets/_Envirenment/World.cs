using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    bool isNight;
	
    public delegate void OnNightChanged(bool isNight);
    public event OnNightChanged notifyNightChange;
	
	void Start () {
			
	}
	
	
	void Update () {
		
	}

	void ChangeNight() {
        isNight = !isNight;
        notifyNightChange(isNight);
    }
}
