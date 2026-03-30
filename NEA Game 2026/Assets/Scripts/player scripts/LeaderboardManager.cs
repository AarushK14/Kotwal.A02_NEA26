using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

// Created: Sprint 6 - Last Edited: Sprint 6
// Purpose: used to display the usernames and scores on the leaderboard

public class LeaderboardManager : MonoBehaviour
{

	public TextMeshProUGUI score1; // Text field for displaying the score
	public TextMeshProUGUI user1; // Text field for displaying the username

	void Start()
	{
		// Grabs the saved score from PlayerPrefs, defaults to 0 if not found
		int score = PlayerPrefs.GetInt ("userScore", 0);
		score1.text = score.ToString ();

		// Grabs the saved username from PlayerPrefs, defaults to empty if not found
		string user = PlayerPrefs.GetString ("user", "");
		user1.text = user;
	}
}