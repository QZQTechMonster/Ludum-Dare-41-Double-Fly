using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour {

    AudioSource audioSource;
    public float maxVolume, speed;
    void Start()
	{
        audioSource = GetComponent<AudioSource>();
    }

	void Update()
	{
        audioSource.volume += speed * Time.deltaTime;
		if(audioSource.volume > maxVolume)
            audioSource.volume = maxVolume;
        if (audioSource.volume < 0)
            audioSource.volume = 0;
    }
}
