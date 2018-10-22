using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayer_GameScore : MonoBehaviour 
{
	public Text currentScoreText;
	public Text maxScoreText;

	private int maxScore;

	/*
	private Boat singlePlayerBoat;
	private void Update()
	{
		if(singlePlayerBoat == null)
		{
			singlePlayerBoat = GameObject.FindObjectOfType<Boat>();
		}
		else
		{
			SetScore(singlePlayerBoat.name, (int)((singlePlayerBoat.trashCollected+1)*singlePlayerBoat.timeAlive));
		}
	}
	*/
	
	public void SetScore(string name, int score)
	{
		currentScoreText.text = name + " : " + score;

		if(maxScore < score)
		{
			maxScore = score;
			maxScoreText.text = "MAX : " + score;
		}
	}
}
