using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{

	public TextMeshProUGUI score1;
	public TextMeshProUGUI user1;

	void Start()
	{
		int sc = PlayerPrefs.GetInt ("userScore", 0);
		score1.text = sc.ToString ();
		string user = PlayerPrefs.GetString ("user", "");
		user1.text = user;

	}
		
	void update()
	{
		
	}
}