using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBoard : MonoBehaviour {

	public BoardSquare B_Tile;
	public BoardSquare R_Tile;
	public GameObject R_Piece;
	public GameObject B_Piece;
	public Piece[,] pieces = new Piece[8,8];

	// Use this for initialization
	void Start () {
		GenerateBoard ();
	}
	//Use ray
	// Update is called once per frame

	void GenerateBoard(){ //generate board and pieces
		for (int x = 0; x < 8; x++) {
			if (x % 2 == 0) {
				for (int y = 0; y < 8; y++) {
					//generate tiles
					if (y % 2 == 0) {
						BoardSquare Bt = (BoardSquare)(Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Bt.transform.SetParent (this.transform);
						Bt.SetValues(x,y,false);
					}
					if (y % 2 == 1) {
						BoardSquare Rt = (BoardSquare)(Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Rt.transform.SetParent (this.transform);
						Rt.SetValues(x,y,true);
						//generate pieces
						if (y == 1) {
							GameObject cool =  Instantiate (R_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
							cool.transform.SetParent (transform);
							Piece p = cool.GetComponent<Piece> ();
							pieces [x, y] = p;
						}
						if (y>4) {
							GameObject cool = Instantiate (B_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
							cool.transform.SetParent (transform);
							Piece p = cool.GetComponent<Piece> ();
							pieces [x, y] = p;
						}
					}
				}
			}
			if (x % 2 == 1) {
				for (int y = 0; y < 8; y++) {
					//generate tiles
					if (y % 2 == 0) {
						BoardSquare Rt = (BoardSquare)(Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Rt.transform.SetParent (this.transform);
						Rt.SetValues(x,y,true);
						//generate pieces
						if (y < 3) {
							GameObject cool = Instantiate (R_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
							cool.transform.SetParent (transform);
							Piece p = cool.GetComponent<Piece> ();
							pieces [x, y] = p;
						}
						if (y == 6) {
							GameObject cool  = Instantiate (B_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
							cool.transform.SetParent (transform);
							Piece p = cool.GetComponent<Piece> ();
							pieces [x, y] = p;
						}
					}
					if (y % 2 == 1) {
						BoardSquare Bt = (BoardSquare)(Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Bt.transform.SetParent (this.transform);
						Bt.SetValues(x,y,false);
					}
				}
			}
		}
	}



}
