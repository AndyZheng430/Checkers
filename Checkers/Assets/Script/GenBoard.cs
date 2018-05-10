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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateBoard(){
		for(int x = 0; x < 8; x += 2){
			for(int y = 0; y < 8; y += 2){
				if(y%2==0){
					Instantiate(B_Tile, new Vector3(x, y, 0),Quaternion.identity);
				}
			}

		}
	}

}
