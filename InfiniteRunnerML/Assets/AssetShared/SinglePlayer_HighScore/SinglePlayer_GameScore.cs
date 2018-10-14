using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayer_GameScore : MonoBehaviour 
{
	public static SinglePlayer_GameScore Instance
	{
		get 
		{

			if(_instance == null)
			{
				GameObject tempInstance = new GameObject();

				_instance = tempInstance.AddComponent<SinglePlayer_GameScore>();
			}

			return _instance;
		}
	}
	public Text currentScoreText;
	public Text maxScoreText;

	private static SinglePlayer_GameScore _instance;
	private int maxScore;

	void Awake () 
	{
		if(_instance != null)
		{
			Destroy(this);
			return;
		}

		_instance = this;
		currentScoreText = gameObject.transform.Find("CURRENT_SCORE").GetComponent<Text>();
		maxScoreText = gameObject.transform.Find("MAX_SCORE").GetComponent<Text>();
	}

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
