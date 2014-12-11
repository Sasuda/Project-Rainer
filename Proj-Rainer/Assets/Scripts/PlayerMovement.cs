using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float PlayerSpeed = 5f;

	public enum PlayerState
	{
		overworld,
		inBattle
	}

	PlayerState playerState;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(playerState == PlayerState.overworld)
		{
			float upDown = Input.GetAxis("Vertical") * PlayerSpeed;
			float leftRight = Input.GetAxis("Horizontal") * PlayerSpeed;
			transform.Translate(leftRight, 0, upDown);
		}
		else if(playerState == PlayerState.inBattle)
		{}
	}

	public void SwapPlayerState()
	{
		if(playerState == PlayerState.overworld)
		{
			playerState = PlayerState.inBattle;
		}
		else if(playerState == PlayerState.inBattle)
		{
			playerState = PlayerState.overworld;
		}
	}
}