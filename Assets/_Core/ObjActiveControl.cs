using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActiveControl : MonoBehaviour {

    [SerializeField] GameObject toActiveObj;
    [SerializeField] GameObject toInactiveObj;
    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != "Player") return;
        toActiveObj.SetActive(true);
        toInactiveObj.SetActive(false);
        Destroy(gameObject);
    }



}
