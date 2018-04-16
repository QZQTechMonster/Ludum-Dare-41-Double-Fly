using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatersManager : ForceBase {

    static WatersManager instance;
    
    public static WatersManager Instance {
		get {
			if(instance == null)
                instance = FindObjectOfType(typeof(WatersManager)) as WatersManager;
            return instance;
        }
	}

    protected override void UpdateActive()
    {
        if(Time.time - lastChangedTime < minChangeTime) return;
        // if (activeIndex > 0 &&
        //     GetSqrDistanceToPlayer(activeIndex) > GetSqrDistanceToPlayer(activeIndex - 1))
        // {
        //     ChangeActive(activeIndex - 1);
        //     lastChangedTime = Time.time;
        //     return;
        // }

        if (activeIndex < obj.Length - 1 &&
            obj[activeIndex+1].transform.position.x < player.position.x)
        {
            ChangeActive(activeIndex + 1);
            lastChangedTime = Time.time;
            return;
        }
    }

    void Start() {
        player = Player.Instance.transform;
        base.StartWithTag("Water");
    }
}
