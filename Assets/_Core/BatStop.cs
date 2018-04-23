using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStop : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Bat") return;
        print("stop");
        other.GetComponent<Rigidbody2D>().isKinematic = true;
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(gameObject);
    }
}
