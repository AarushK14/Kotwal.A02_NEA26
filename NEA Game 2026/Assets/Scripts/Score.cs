using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

	public TextMeshPro ScoreCounter;
	int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score);
		ScoreCounter.text = "Score: " + score.ToString();
	}
	public void OnCollisionEnter2d(Collider2D other){
		if (other.gameObject.tag == "coin") {
			score += 2;
		}
	}
}
