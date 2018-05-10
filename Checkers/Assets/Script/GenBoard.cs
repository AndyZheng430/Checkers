using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBoard : MonoBehaviour {

	public GameObject B_Tile;
	public GameObject R_Tile;
	public GameObject R_Piece;
	public GameObject B_Piece;

	// Use this for initialization
	void Start () {
		GenerateBoard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateBoard(){
		for (int x = 0; x < 8; x++) {
			if (x % 2 == 0) {
				for (int y = 0; y < 8; y++) {
					if (y % 2 == 0) {
						Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity);
					}
					if (y % 2 == 1) {
						Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity);
					}
				}
			}
			if (x % 2 == 1) {
				for (int y = 0; y < 8; y++) {
					if (y % 2 == 0) {
						Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity);
					}
					if (y % 2 == 1) {
						Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity);
					}
				}
			}
		}
	}

}
