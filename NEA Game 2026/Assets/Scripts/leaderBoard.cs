using UnityEngine;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
	private const int MaxEntries = 5; // Top 5 scores
	private List<int> scores = new List<int>();

	void Start()
	{
		LoadScores();
	}

	public void AddScore(int newScore)
	{
		scores.Add(newScore);
		scores.Sort((a, b) => b.CompareTo(a)); // Sort descending
		if (scores.Count > MaxEntries)
			scores.RemoveAt(scores.Count - 1);

		SaveScores();
	}

	private void SaveScores()
	{
		for (int i = 0; i < scores.Count; i++)
		{
			PlayerPrefs.SetInt("Score" + i, scores[i]);
		}
		PlayerPrefs.SetInt("userScore", scores.Count);
		PlayerPrefs.Save();
	}

	private void LoadScores()
	{
		scores.Clear();
		int count = PlayerPrefs.GetInt("userScore", 0);
		for (int i = 0; i < count; i++)
		{
			scores.Add(PlayerPrefs.GetInt("Score" + i, 0));
		}
	}

	public List<int> GetScores()
	{
		return new List<int>(scores);
	}
}