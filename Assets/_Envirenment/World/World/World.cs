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
    [SerializeField] bool canControl;
    float lastChangeTime = -1;

    public delegate void OnNightChanged(bool isNight);
    public event OnNightChanged notifyNightChange;

    public void SetControl(bool can)
    {
        canControl = can;
    }

	void Start () {
        isNight = false;
        ChangeNight();
    }
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) && canControl) {
            ChangeNight();
        }
	}

	public void ChangeNight() {
        if(lastChangeTime == Time.time) return;
        lastChangeTime = Time.time;
        isNight = !isNight;
        notifyNightChange(isNight);
    }

    public void ChangeNightByBool(bool night) {
        if(night == isNight) return;
        ChangeNight();
    }

}
