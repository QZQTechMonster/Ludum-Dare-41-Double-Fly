using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMode : MonoBehaviour {

	[SerializeField] GameObject batPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject batObj = Instantiate(batPrefab, pos, Quaternion.identity);
        batObj.GetComponent<Rigidbody2D>().AddForce( Vector2.down*50 +Vector2.left*350);

        Destroy(gameObject);
    }
}
