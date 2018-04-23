using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActive : MonoBehaviour {


    [SerializeField] GameObject audioD;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        audioD.SetActive(true);
        Destroy(gameObject);
    }
}
