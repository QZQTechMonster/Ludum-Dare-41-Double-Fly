using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatersManager : ForceBase {

    static WatersManager instance;
    float offset = 0.5f;

    public static WatersManager Instance {
		get {
			if(instance == null)
                instance = FindObjectOfType(typeof(WatersManager)) as WatersManager;
            return instance;
        }
	}

    protected override void UpdateActive()
    {
        if (activeIndex < obj.Length - 1 &&
            obj[activeIndex+1].transform.position.x + offset < player.position.x)
        {
            obj[activeIndex].GetComponent<Water>().SetNotActive();
            obj[activeIndex + 1].GetComponent<Water>().SetActive();
            ChangeActive(activeIndex + 1);
            lastChangedTime = Time.time;
            return;
        }
    }

    void Start() {
        player = Player.Instance.transform;
        base.StartWithTag("Water");
        obj[activeIndex].GetComponent<Water>().SetActive();
    }
}
