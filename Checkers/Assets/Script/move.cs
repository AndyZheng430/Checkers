using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public GameObject RLight;
	public GameObject m1;
	public GameObject m2;

	public Vector3 pos; 
	public Vector3 Pmove1;
	public Vector3 Pmove2;
	public Vector3 Pmove3;
	public Vector3 Pmove4; 

	public bool B = false;
	public bool R = false;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
		if (gameObject.CompareTag ("Red"))
			R = true;
		else
			B = true;
	}
	
	// Update is called once per frame
	void Update () {
		int layermask = 1 << 8;
		layermask = ~layermask;

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)), out hit, Mathf.Sqrt(2), layermask)) {
			Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, 1)) * hit.distance, Color.white);
			Debug.Log ("Hit1");
			if (hit.collider.gameObject.CompareTag("Red")) {
				if (B && pos.x + 2 < 8 && pos.x + 2 >= 0 && pos.z + 2 < 8 && pos.z + 2 >= 0) {
					Pmove1 = new Vector3 (pos.x + 2, pos.y, pos.z + 2);
				} 
			}
			if (hit.collider.gameObject.CompareTag ("Black")) {
				if (R && pos.x + 2 < 8 && pos.x + 2 >= 0 && pos.z + 2 < 8 && pos.z + 2 >= 0) {
					Pmove1 = new Vector3 (pos.x + 2, pos.y, pos.z + 2);
				}
			}
		}
		if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)), out hit, Mathf.Sqrt(2), layermask)) {
			Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0, -1)) * hit.distance, Color.white);
			Debug.Log ("Hit2");

		}
		if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)), out hit, Mathf.Sqrt(2), layermask)) {
			Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (1, 0, -1)) * hit.distance, Color.white);
			Debug.Log ("Hit3");

		}
		if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (-1, 0, 1)), out hit, Mathf.Sqrt(2), layermask)) {
			Debug.DrawRay (transform.position, transform.TransformDirection (new Vector3 (-1, 0	, 1)) * hit.distance, Color.white);
			Debug.Log ("Hit4");

		}
	}

	/*void OnMouseDown(){
		if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("Black")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z - 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z - 1f);
		} else if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("Red")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z + 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z + 1f);
		} else if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("RedKing")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z + 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z + 1f);
			Pmove3 = new Vector3 (pos.x - 1f, pos.y, pos.z - 1f);
			Pmove4 = new Vector3 (pos.x + 1f, pos.y, pos.z - 1f);
		} else if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("BlackKing")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z + 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z + 1f);
			Pmove3 = new Vector3 (pos.x - 1f, pos.y, pos.z - 1f);
			Pmove4 = new Vector3 (pos.x + 1f, pos.y, pos.z - 1f);
		}
		if (Pmove1.x >= 0 && Pmove1.x < 8 && Pmove1.z >= 0 && Pmove1.z < 8 && Input.GetMouseButtonDown (0)) {
			m1 = (GameObject)(Instantiate (RLight, Pmove1, Quaternion.identity));	
		} 
		if (Pmove2.x >= 0 && Pmove2.x < 8 && Pmove2.z >= 0 && Pmove2.z < 8 && Input.GetMouseButtonDown (0)) {
			m2 = (GameObject)(Instantiate (RLight, Pmove2, Quaternion.identity));
		}
	}*/

}
