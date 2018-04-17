using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresManager : ForceBase {

    static FiresManager instance;

    float offset = 0.5f;
    public static FiresManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(FiresManager)) as FiresManager;
            return instance;
        }
    }

    protected override void UpdateActive()
    {
        if (activeIndex < obj.Length - 1 &&
            obj[activeIndex].transform.position.x + offset < player.position.x)
        {
            obj[activeIndex].GetComponent<Fire>().SetNotActive();
            obj[activeIndex + 1].GetComponent<Fire>().SetActive();

            ChangeActive(activeIndex + 1);
            lastChangedTime = Time.time;
            return;
        }
    }

    void Start() {
        player = Player.Instance.transform;
        base.StartWithTag("Fire");
        obj[activeIndex].GetComponent<Fire>().SetActive();
    }
	
}
