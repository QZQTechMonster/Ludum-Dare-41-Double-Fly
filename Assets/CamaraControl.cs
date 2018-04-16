using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour {
    Transform player;
	void Start() {
        player = GameObject.FindGameObjectWithTag("Player").
		GetComponent<Transform>();

        
    }

	void Update() {
        Vector3 pos = player.position;
        pos.z = -10;
        pos.y = 0;
        transform.position = pos;
    }

}
