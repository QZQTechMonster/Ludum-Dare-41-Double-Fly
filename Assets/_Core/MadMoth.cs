using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadMoth : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        World.Instance.ChangeNightByBool(true);
        Destroy(gameObject);
    }
}
