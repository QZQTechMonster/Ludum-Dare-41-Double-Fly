using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static Player instance;

    [SerializeField] float maxSpeed, maxForce;
    Rigidbody2D rgb;

    // envirenment
    Vector3 fireActivePos, waterActivePos;
    bool isNight;


    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(Player)) as Player;
            return instance;
        }
    }
    void Awake() {
        FiresManager.Instance.notifyActiveChange += ChangeFireActive;
        WatersManager.Instance.notifyActiveChange += ChangeWaterActive;
        World.Instance.notifyNightChange += ChangeNight;
        
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(isNight) {
            Seek(fireActivePos);
        } else {
            Flee(waterActivePos);
        }
        
    }

    void Seek(Vector3 targetPos) {
        rgb.AddForce((targetPos - transform.position).normalized * maxForce);
        if(rgb.velocity.magnitude > maxSpeed) {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
    }
    void Flee(Vector3 targetPos) {
        rgb.AddForce(-(targetPos - transform.position).normalized * maxForce);
        if (rgb.velocity.magnitude > maxSpeed) {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
    }
    
    void ChangeFireActive(Transform fire) {
        fireActivePos = fire.position;
    }

    void ChangeWaterActive(Transform fire) {
        waterActivePos = fire.position;
    }

    void ChangeNight(bool isNight) {
        this.isNight = isNight;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, waterActivePos);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, fireActivePos);        
    }
}
