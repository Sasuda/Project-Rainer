using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float PlayerSpeed = 5f;
	public float RotationSpeed = 5f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float upDown = Input.GetAxis("Vertical") * PlayerSpeed;
		float leftRight = Input.GetAxis("Horizontal") * RotationSpeed;
		transform.Translate(leftRight, 0, upDown);
	}
}
