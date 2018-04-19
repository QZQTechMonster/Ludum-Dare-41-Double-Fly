using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour {

    static World instance;
    public static World Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(World)) as World;
            return instance;
        }
    }
    bool isNight;
	
    public delegate void OnNightChanged(bool isNight);
    public event OnNightChanged notifyNightChange;
	
	void Start () {
        isNight = false;
        ChangeNight();
    }
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
            ChangeNight();
        }
	}

	void ChangeNight() {
        isNight = !isNight;
        notifyNightChange(isNight);
        
    }
}
