using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BackToMenu : MonoBehaviour {

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
