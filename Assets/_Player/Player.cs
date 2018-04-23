using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    static Player instance;
    // [SerializeField] GameObject bat, moth;
    [SerializeField] Animator bat, moth;
    [SerializeField] Text tutorialText;
    /**
    * move
    */
    [SerializeField] float maxSpeed, maxForce;
    Rigidbody2D rgb;

    /**
    * envirenment
    */
    Vector3 fireActivePos, waterActivePos;
    bool isNight;

    /**
    * Line
    */
    [SerializeField] LineRenderer nightLine, dayLine;

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
        UpdateLines();
        
        if(isNight) {
            Seek(fireActivePos);
        } else {
            Flee(waterActivePos);
        }
        
    }

    private void UpdateLines()
    {
        nightLine.SetPosition(0, transform.position);
        nightLine.SetPosition(1, fireActivePos);

        dayLine.SetPosition(0, transform.position);
        dayLine.SetPosition(1, waterActivePos);
    }

    void LateUpdate() {
        if (rgb.velocity.magnitude > maxSpeed) {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
    }
    void Seek(Vector3 targetPos) {
        rgb.AddForce((targetPos - transform.position).normalized * maxForce);
    }
    void Flee(Vector3 targetPos) {
        rgb.AddForce(-(targetPos - transform.position).normalized * maxForce);
    }
    
    void ChangeFireActive(Transform fire) {
        fireActivePos = fire.position;
    }

    void ChangeWaterActive(Transform fire) {
        waterActivePos = fire.position;
    }

    void ChangeNight(bool isNight) {
        this.isNight = isNight;
        if(isNight) {
            // bat.SetActive(false);
            // moth.SetActive(true);
            bat.SetBool("isActive", false);
            moth.SetBool("isActive", true);
            moth.transform.position -= new Vector3(0, 0, 0.1f);
            bat.transform.position += new Vector3(0, 0, 0.1f);

            nightLine.startWidth = 0.3f;
            dayLine.startWidth = 3f;
        } else {
            // bat.SetActive(true);
            // moth.SetActive(false);
            bat.SetBool("isActive", true);
            moth.SetBool("isActive", false);
            bat.transform.position -= new Vector3(0, 0, 0.1f);
            moth.transform.position += new Vector3(0, 0, 0.1f);

            nightLine.startWidth = 3f;
            dayLine.startWidth = 0.3f;
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        if(GameController.instance.isGod) return;
        if (other.tag == "Fire")
        {
            bat.SetTrigger("Die");
            moth.SetTrigger("Die");
            rgb.isKinematic = true;
            rgb.velocity = Vector2.zero;
            tutorialText.text = "Oh no!!! Moth Died";
            GameController.instance.StartCoroutine("BackMenuInOneSecond");

        }
    }


}
