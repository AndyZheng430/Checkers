using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evalution : MonoBehaviour {

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
	//minmax algorithm 
	void MinMax(int depth, Checkers game, int alpha, int beta, bool Turn){
		if (depth == 0 && Turn == true) {//computer 
			Evalution (1);
		} else if (depth == 0 && Turn == false) {//person
			Evalution (0);
		}
		if (Turn) { //computer
			int bestMove = -9999;
			for (int i = 0; i < newMove.length; i++) { //newMove is an array contains possible moves 
				game.possibleMove (newMove [i]);
				bestMove = Mathf.Max (bestMove, MinMax (depth - 1, !Turn));
				alpha = Mathf.Max (alpha, bestMove);
				if (beta <= alpha) {
					return bestMove;
				}
			} 
			return bestMove;
		} else { //
			int bestMove = 9999;
			for (int i = 0; i < newMove.length; i++) { //newMove is an array contains possible moves 
				game.possibleMove (newMove [i]);
				bestMove = Mathf.Max (bestMove, MinMax (depth - 1, !Turn));
				beta = Mathf.Max (beta, bestMove);
				if (beta <= alpha) {
					return bestMove;
				}
			} 
			return bestMove;
		}
	}
	//evaluate board for players
	void Evaluation(int PlayTurn){
		// takes values of red pieces on the board
		RPValue = Reds.Length + 10*(RedKings.Length); 
		// takes values of black pieces on the board
		BPValue = Blacks.Length + 10*(BlackKings.Length); 
		if (PlayTurn == 0) { // evaluates for red
			//evaluation of difference between red and black pieces
			RTotal = RPValue - BPValue;
			foreach (GameObject r in Reds) {
				//evaluate distance from end of board for red
				RTotal += Mathf.RoundToInt(r.transform.position.z);
				//evaluates defense 
				if (r.transform.position.x == 0 || r.transform.position.x == 7 || r.transform.position.z == 0) {
					RTotal += 2;
				} else {
					BR_Eval (0, 1);
					BL_Eval (0, 1);
					TL_Eval (0, 1);
					TR_Eval (0, 1);
				}
			}
			foreach (GameObject rk in RedKings) {
				if (rk.transform.position.x == 0 || rk.transform.position.x == 7 || rk.transform.position.z == 0) {
					RTotal += 4;
				} else {
					BR_Eval (0, 2);
					BL_Eval (0, 2);
					TL_Eval (0, 2);
					TR_Eval (0, 2);
				}
			}
		} else if (PlayTurn == 1) { // evaluates for black
			//evaluation of difference between black and red pieces
			BTotal = BPValue - RPValue;
			foreach (GameObject b in Blacks) {
				//evaluate distance from end of board for black
				BTotal += 7 - Mathf.RoundToInt(b.transform.position.z);
				//evaluates defense
				if (b.transform.position.x == 0 || b.transform.position.x == 7 || b.transform.position.z == 7) {
					BTotal += 2;
				} else {
					BR_Eval (1, 1);
					BL_Eval (1, 1);
					TL_Eval (1, 1);
					TR_Eval (1, 1);
				}
			}
			foreach (GameObject bk in BlackKings) {
				if (bk.transform.position.x == 0 || bk.transform.position.x == 7 || bk.transform.position.z == 7) {
					BTotal += 4;
				} else {
					BR_Eval (1, 2);
					BL_Eval (1, 2);
					TL_Eval (1, 2);
					TR_Eval (1, 2);
				}
			}

		}
	}
	//1,0,1
	void TR_Eval(int k, int value){ 
		int layerMask = 1 << 8;
		layerMask =~ layerMask;
		RaycastHit hit;
		if(k==0){
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Red")||hit.collider.gameObject.CompareTag ("RedK")) {
					RTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Black")||hit.collider.gameObject.CompareTag ("BlackK")) {
					RTotal -= 1 * value;
				} 
			}
		}else if (k == 1) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Black") || hit.collider.gameObject.CompareTag ("BlackK")) {
					BTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Red") || hit.collider.gameObject.CompareTag ("RedK")) {
					BTotal -= 1 * value;
				} 
			}
		}
	}
	//1,0,-1
	void BR_Eval(int k, int value){
		int layerMask = 1 << 8;
		layerMask =~ layerMask;
		RaycastHit hit;
		if(k==0){
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Red")||hit.collider.gameObject.CompareTag ("RedK")) {
					RTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Black")||hit.collider.gameObject.CompareTag ("BlackK")) {
					RTotal -= 1 * value;
				} 
			}
		}else if (k == 1) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Black") || hit.collider.gameObject.CompareTag ("BlackK")) {
					BTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Red") || hit.collider.gameObject.CompareTag ("RedK")) {
					BTotal -= 1 * value;
				} 
			}
		}
	}
	//-1,0,1
	void TL_Eval(int k, int value){
		int layerMask = 1 << 8;
		layerMask =~ layerMask;
		RaycastHit hit;
		if(k==0){
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, 1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0, 1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Red")||hit.collider.gameObject.CompareTag ("RedK")) {
					RTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Black")||hit.collider.gameObject.CompareTag ("BlackK")) {
					RTotal -= 1 * value;
				} 
			}
		}else if (k == 1) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, 1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0, 1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Black") || hit.collider.gameObject.CompareTag ("BlackK")) {
					BTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Red") || hit.collider.gameObject.CompareTag ("RedK")) {
					BTotal -= 1 * value;
				} 
			}
		}
	}
	//-1,0,-1
	void BL_Eval(int k, int value){
		int layerMask = 1 << 8;
		layerMask =~ layerMask;
		RaycastHit hit;
		if (k == 0) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Red")||hit.collider.gameObject.CompareTag ("RedK")) {
					RTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Black")||hit.collider.gameObject.CompareTag ("BlackK")) {
					RTotal -= 1 * value;
				} 
			}
		} else if (k == 1) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)), out hit, Mathf.Sqrt (2), layerMask)) {
				Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)) * hit.distance, Color.white);
				if (hit.collider.gameObject.CompareTag ("Black") || hit.collider.gameObject.CompareTag ("BlackK")) {
					BTotal += 1 * value;
				} else if (hit.collider.gameObject.CompareTag ("Red") || hit.collider.gameObject.CompareTag ("RedK")) {
					BTotal -= 1 * value;
				} 
			}
		}
	}
}
