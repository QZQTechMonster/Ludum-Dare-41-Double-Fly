using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GodButton : MonoBehaviour {


    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(StartGodMode);
    }

    public void StartGodMode()
    {
        GameController.instance.isGod = true;
        SceneManager.LoadScene("Main");
    }
}
