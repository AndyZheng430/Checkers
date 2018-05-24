using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBoard : MonoBehaviour {

	public GameObject B_Tile;
	public GameObject R_Tile;
	public GameObject R_Piece;
	public GameObject B_Piece;

	public Vector2 mouseover;

	// Use this for initialization
	void Start () {
		GenerateBoard ();
	}
	//Use ray
	// Update is called once per frame
	void Update () {
		UpdateMouseOver ();
	}

	private UpdateMouseOver(){
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 25.0f, LayerMask.GetMask)
	}

	void GenerateBoard(){ //generate board and pieces
		for (int x = 0; x < 8; x++) {
			if (x % 2 == 0) {
				for (int y = 0; y < 8; y++) {
					//generate tiles
					if (y % 2 == 0) {
						GameObject Bt = (GameObject)(Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Bt.transform.SetParent (this.transform);
					}
					if (y % 2 == 1) {
						GameObject Rt = (GameObject)(Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Rt.transform.SetParent (this.transform);
						//generate pieces
						if (y == 1) {
							Instantiate (R_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
						}
						if (y>4) {
							Instantiate (B_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
						}
					}
				}
			}
			if (x % 2 == 1) {
				for (int y = 0; y < 8; y++) {
					//generate tiles
					if (y % 2 == 0) {
						GameObject Rt = (GameObject)(Instantiate (R_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Rt.transform.SetParent (this.transform);
						//generate pieces
						if (y < 3) {
							Instantiate (R_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
						}
						if (y == 6) {
							Instantiate (B_Piece, new Vector3 (x, 0.1f, y), Quaternion.identity);
						}
					}
					if (y % 2 == 1) {
						GameObject Bt = (GameObject)(Instantiate (B_Tile, new Vector3 (x, 0, y), Quaternion.identity));
						Bt.transform.SetParent (this.transform);
					}
				}
			}
		}
	}

}
