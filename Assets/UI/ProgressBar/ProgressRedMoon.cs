using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressRedMoon : MonoBehaviour {

	void Start () {
        Vector3 pos = transform.position;
		pos.x = GetComponentInParent<Progress>().GetRedMoonModePos();
        transform.position = pos;
    }

}
