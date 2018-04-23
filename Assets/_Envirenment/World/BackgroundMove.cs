using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    RectTransform rectTransform;
    Transform playerTransform;
    float lastPlayerX, minX, maxX;
    Vector3 thisPosition;
    public float speed;

	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rectTransform = GetComponent<RectTransform>();

        float width = rectTransform.offsetMax.x - rectTransform.offsetMin.x;
        maxX = width / 2f - Screen.width / 2f;
        minX = -width / 2f - Screen.width / 2f;

        thisPosition = rectTransform.anchoredPosition3D;
        thisPosition.x = maxX;
        rectTransform.anchoredPosition3D = thisPosition;

        lastPlayerX = playerTransform.position.x;
	}

    void Update()
    {
        thisPosition.x -= (playerTransform.position.x - lastPlayerX) * speed;
        if (thisPosition.x < minX) thisPosition.x += (maxX - minX);
        lastPlayerX = playerTransform.position.x;
        rectTransform.anchoredPosition3D = thisPosition;
    }

	public void setSpeed(float newSpeed) {
        speed = newSpeed;
    }
}
