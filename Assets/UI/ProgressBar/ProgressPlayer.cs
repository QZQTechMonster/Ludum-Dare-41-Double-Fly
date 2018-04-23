using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPlayer : MonoBehaviour {

    Progress progress;
    Vector3 pos;
    float start = -180, end = 200;
    void Start()
    {
        progress = GetComponentInParent<Progress>();
        pos = transform.localPosition;
    }

    void Update()
    {
        pos.x = start + (end - start) * progress.GetProgress();
        transform.localPosition = pos;
    }
}
