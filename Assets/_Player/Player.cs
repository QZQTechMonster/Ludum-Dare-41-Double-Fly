using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float maxSpeed;
    Rigidbody2D rgb;

    // envirenment
    Vector3 fireActivePos;
    bool isNight;

    void Awake() {
        GameObject.FindGameObjectWithTag("FireManager").
            GetComponent<FiresManager>().notifyActiveChange += ChangeFireActive;
        GameObject.FindGameObjectWithTag("World").
            GetComponent<World>().notifyNightChange += ChangeNight;

        rgb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(isNight) {
            Seek(fireActivePos);
        } else {
            
        }
        
    }

    void Seek(Vector3 targetPos) {
        rgb.velocity = (targetPos - transform.position).normalized * maxSpeed;
    }

    void ChangeFireActive(Transform fire) {
        fireActivePos = fire.position;
    }

    void ChangeNight(bool isNight) {
        this.isNight = isNight;
    }
}
