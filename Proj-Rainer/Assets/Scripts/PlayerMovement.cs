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
		float translation = Input.GetAxis("Vertical") * PlayerSpeed;
		float rotation = Input.GetAxis("Horizontal") * RotationSpeed;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}
}
