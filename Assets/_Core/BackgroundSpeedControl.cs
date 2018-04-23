using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpeedControl : MonoBehaviour {

    [SerializeField] BackgroundMove[] moveObjs;
    // [SerializeField] float[] speeds;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        for (int i = 0; i < moveObjs.Length; ++i) {
            moveObjs[i].speed *= 1.5f;
        }

            Destroy(gameObject);
    }
}
