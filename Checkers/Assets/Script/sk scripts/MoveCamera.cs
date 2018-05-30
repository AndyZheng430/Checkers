using UnityEngine;
using System.Collections;

public class MoveCamera: MonoBehaviour {
	
	public float speedH = 2.0f;
	public float speedV = 2.0f;
	public float speed = 2.0f;
	public GameObject character;
	
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	
	void Update () {
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");
		character.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}