using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressFull : MonoBehaviour {

    Progress progress;
    Image image;
    void Start () {
        progress = GetComponentInParent<Progress>();
        image = GetComponent<Image>();
    }
	
	void Update () {
        image.fillAmount = progress.GetProgress();
    }
}
