using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public bool isGod;
    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartNormalMode() {
        isGod = false;
        SceneManager.LoadScene("Main");
    }

    public void StartGodMode()
    {
        isGod = true;
        SceneManager.LoadScene("Main");
    }

	IEnumerator BackMenuInOneSecond() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
	}

}
