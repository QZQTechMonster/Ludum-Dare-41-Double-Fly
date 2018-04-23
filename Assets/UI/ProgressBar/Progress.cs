using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {
	[SerializeField] Transform player, end, redMoonMode;
    [SerializeField] Transform barStartT, barEndT;

    float gameStart, gameEnd;
    float barStart, barEnd;

	void Awake()
	{
        gameStart = player.position.x;
        gameEnd = end.position.x;
    }
	public float GetProgress() {
        return (player.position.x - gameStart) / (gameEnd - gameStart);
    }

	public float GetRedMoonModePos() {
        return GeBarPos(redMoonMode);
    }

    public float GeCurrentPos()
    {	
		// print(GeBarPos(player));
        return GeBarPos(player);
    }

    public float GeBarPos(Transform t)
    {
        barStart = barStartT.position.x;
        barEnd = barEndT.position.x;
        float percent = (t.position.x - gameStart) / (gameEnd - gameStart);
        return percent * (barEnd - barStart) + barStart;
    }
}
