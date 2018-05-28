using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquare : MonoBehaviour {

	public int xCoord;
	public int yCoord;
	public bool isRed;

	public void SetValues(int x, int y, bool r){
		xCoord = x;
		yCoord = y;
		isRed = r;
	}
}
