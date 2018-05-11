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

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Destroy (m1);
			Destroy (m2);
		}
	}

	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("Black")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z - 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z - 1f);
		} else if (Input.GetMouseButtonDown (0) && gameObject.CompareTag ("Red")) {
			Pmove1 = new Vector3 (pos.x - 1f, pos.y, pos.z + 1f);
			Pmove2 = new Vector3 (pos.x + 1f, pos.y, pos.z + 1f);
		} else {
			Debug.Log ("null");
		}
		if (Pmove1.x >= 0 && Pmove1.x < 8 && Pmove1.z >= 0 && Pmove1.z < 8 && Input.GetMouseButtonDown (0)) {
			m1 = (GameObject)(Instantiate (RLight, Pmove1, Quaternion.identity));
		} 
		if (Pmove2.x >= 0 && Pmove2.x < 8 && Pmove2.z >= 0 && Pmove2.z < 8 && Input.GetMouseButtonDown (0)) {
			m2 = (GameObject)(Instantiate (RLight, Pmove2, Quaternion.identity));
		}
	}
}
