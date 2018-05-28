using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour {

	private GameObject lastSelected = null; // store last selected object reference

	
	void Update () {
		if (Input.GetMouseButtonDown(0)) { // if LMB clicked
			bool cubeHit = false;
			RaycastHit raycastHit = new RaycastHit(); // create new raycast hit info object
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out raycastHit)) { // create ray from screen's mouse position to world and store info in raycastHit object
				if (raycastHit.collider.tag == "Red") { // we just want to hit objects tagged with "Cube"
					cubeHit = true; // yup, we hit it!
					Debug.Log (raycastHit.collider.tag);
					Debug.Log ("x:" + raycastHit.collider.gameObject.transform.position.x + " y:" + raycastHit.collider.gameObject.transform.position.y + " z:" + raycastHit.collider.gameObject.transform.position.z);
				} 
			}
			
			Deselect (lastSelected); // deselect last hit object
			if (cubeHit) 
				Select (raycastHit.collider.gameObject); // select new cube
		}
	}
	
	private void Select (GameObject g) {
		// when we select cube, we disable rotation script to make it stationary
		lastSelected = g;
		

		//Vector3 newPos = g.transform.position;
		//newPos.z = -1f;
		//transform.position = newPos;
	}
	
	private void Deselect (GameObject g) {
		if (lastSelected != null) { // if we have already selected object
			lastSelected = g;
		}
	}
}
