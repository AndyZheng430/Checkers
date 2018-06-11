using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour {

	public bool isRed;
	public bool isKing;

    public void isColor() {
        if (this.gameObject.CompareTag("Black") || this.gameObject.CompareTag("BlackK"))
        {
            isRed = false;
        }
        else if (this.gameObject.CompareTag("Red") || this.gameObject.CompareTag("RedK")) {
            isRed = true;
        }
    }

	public bool isForceMove(Pieces[,] board, int x, int y){
		if (isRed || isKing) {
			//top left
			if (x >= 2 && y <= 5) {
				Pieces p = board [x - 1, y + 1];
				if (p != null && p.isRed != isRed) {
					if (board [x - 2, y + 2] == null) {
						return true;
					}
				}
			}
			//top right
			if (x <= 5 && y <= 5) {
				Pieces p = board [x + 1, y + 1];
				if (p != null && p.isRed != isRed) {
					if (board [x + 2, y + 2] == null) {
						return true;
					}
				}
			}
		}
		if (!isRed || isKing) {
			//bot left
			if (x >= 2 && y >= 2) {
				Pieces p = board [x - 1, y - 1];
				if (p != null && p.isRed != isRed) {
					if (board [x - 2, y - 2] == null) {
						return true;
					}
				}
			}
			//bot right
			if (x <= 5 && y >= 2) {
				Pieces p = board [x + 1, y - 1];
				if (p != null && p.isRed != isRed) {
					if (board [x + 2, y - 2] == null) {
						return true;
					}
				}
			}
		}
		return false;
	}
    public bool isNotForceMove(Pieces[,] board, int x, int y)
    {
        if (isRed || isKing)
        {
            //top left
            if (x >= 2 && y <= 5)
            {
                Pieces p = board[x - 1, y + 1];
                if (p == null)
                {
                    return true;
                }
            }
            //top right
            if (x <= 5 && y <= 5)
            {
                Pieces p = board[x + 1, y + 1];
                if (p == null)
                {
                    return true;
                }
            }
        }
        if (!isRed || isKing)
        {
            //bot left
            if (x >= 2 && y >= 2)
            {
                Pieces p = board[x - 1, y - 1];
                if (p == null)
                {
                    return true;
                }
            }
            //bot right
            if (x <= 5 && y >= 2)
            {
                Pieces p = board[x + 1, y - 1];
                if (p == null)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool ValidMove(Pieces[,] board, int x1, int y1, int x2, int y2){
		if (board [x2, y2] != null) {
			return false;
		} 
		int deltaMove = (int)Mathf.Abs (x1 - x2);
		int deltaMovey = y2 - y1;
		if (isRed || isKing) {
			if (deltaMove == 1) {
				if (deltaMovey == 1) {
					return true;
				}

			}
			if (deltaMove == 2) {
				if (deltaMovey == 2) {
					Pieces p = board [(x1 + x2) / 2, (y1 + y2) / 2];
					if (p != null && p.isRed != isRed) {
						return true;
					}
				}
			}
		}
		if (!isRed || isKing) {
			if (deltaMove == 1) {
				if (deltaMovey == -1) {
					return true;
				}

			}
			if (deltaMove == 2) {
				if (deltaMovey == -2) {
					Pieces p = board [(x1 + x2) / 2, (y1 + y2) / 2];
					if (p != null && p.isRed != isRed) {
						return true;
					}
				}
			}
		}
		return false;
	}
}
