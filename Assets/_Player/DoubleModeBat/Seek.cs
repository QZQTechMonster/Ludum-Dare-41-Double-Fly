using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    Rigidbody2D rgb;
    Transform player;
    [SerializeField] float maxSpeed, maxForce;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rgb = GetComponent<Rigidbody2D>();
    }
    
	// Update is called once per frame
	void Update () {
        rgb.AddForce((player.position - transform.position).normalized * maxForce);
	}

    void LateUpdate()
    {
        if (rgb.velocity.magnitude > maxSpeed)
        {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
    }
}
