using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumContrl : MonoBehaviour {

    [SerializeField]BGMControl bgm;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        bgm.speed *= -3;
        Destroy(gameObject);
    }
}
