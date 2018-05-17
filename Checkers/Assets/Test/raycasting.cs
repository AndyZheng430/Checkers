 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasting : MonoBehaviour {

	public GameObject[] hold = new GameObject[4]; 
	public int x;

	// Use this for initialization
	void Start () {
		find();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void find(){
		int layerMask = 1 << 8;
		layerMask =~ layerMask;

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (new Vector3 (0, 0, 1)), out hit, Mathf.Infinity, layerMask)) {
			if (hit.collider.gameObject) {
				hold [x] = hit.collider.gameObject;
				x++;
				hit.collider.gameObject.GetComponent<BoxCollider> ().enabled = false;
			}

		}
	}
	void OnMouseDown(){
		for (int y = 0; y < hold.Length; y++) {
			if (hold[y].transform.position.z<1 && hold[y].transform.position.z>2){
				gameObject.transform.Translate (new Vector3 (0, 0, 1));
			}
		}
	}
}
