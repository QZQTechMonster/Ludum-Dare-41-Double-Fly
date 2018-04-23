using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalButton : MonoBehaviour {

	void Awake()
	{
        GetComponent<Button>().onClick.AddListener(StartNormalMode);
    }

    public void StartNormalMode()
    {
        GameController.instance.isGod = false;
        SceneManager.LoadScene("Main");
    }

}
