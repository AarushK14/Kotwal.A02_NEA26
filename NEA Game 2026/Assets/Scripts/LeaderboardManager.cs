using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{

	public Text score1;
	public Text user1;

	void Start()
	{
		
	}
		
	void update()
	{
		score1.text = PlayerPrefs.GetInt ("userScore", 0).ToString ();
		user1.text = PlayerPrefs.GetString ("user", "");
	}
}