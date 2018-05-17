using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDecider : MonoBehaviour {

	//array of red pieces 
	public GameObject[] Reds;
	public GameObject[] RedKings;
	//array of black pieces 
	public GameObject[] Blacks; 
	public GameObject[] BlackKings; 

	//total value of pieces
	//normal pieces are worth 1, kings are worth 10
	public int RPValue = 0;
	public int BPValue = 0; 

	//total points for red after evaluation
	public int RTotal = 0;
	//total points for black after evaluation
	public int BTotal = 0;

	// Use this for initialization
	void Start () {
		Reds = GameObject.FindGameObjectsWithTag ("Red");
		RedKings = GameObject.FindGameObjectsWithTag ("RedK");
		Blacks = GameObject.FindGameObjectsWithTag ("Black");
		BlackKings = GameObject.FindGameObjectsWithTag ("BlackK");
	}

	// Update is called once per frame
	void Update () {
		//constantly updates arrays to show pieces left
		Reds = GameObject.FindGameObjectsWithTag ("Red");
		RedKings = GameObject.FindGameObjectsWithTag ("RedK");
		Blacks = GameObject.FindGameObjectsWithTag ("Black");
		BlackKings = GameObject.FindGameObjectsWithTag ("BlackK");

	}
		
	void Evaluation(int PlayTurn){
		// takes values of red pieces on the board
		RPValue = Reds.Length + 10*(RedKings.Length); 
		// takes values of black pieces on the board
		BPValue = Blacks.Length + 10*(BlackKings.Length); 
		if (PlayTurn == 0) { // evaluates for red
			//evaluation of difference between red and black pieces
			RTotal = RPValue - BPValue;

		} else if (PlayTurn == 1) { // evaluates for black
			//evaluation of difference between black and red pieces
			BTotal = BPValue - RPValue;

		}
	}
}
