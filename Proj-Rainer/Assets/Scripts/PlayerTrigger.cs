using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour 
{
	public GameObject battleManager;
	public GameObject player;
	public BattleManager battleManagerScript;
	public PlayerMovement playerMovementScript;

	// Use this for initialization
	void Start () 
	{
		battleManager = GameObject.FindWithTag("BattleManager");
		battleManagerScript = (BattleManager)battleManager.GetComponent("BattleManager");
		player = GameObject.FindWithTag("Player");
		playerMovementScript = (PlayerMovement)player.GetComponent("PlayerMovement");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider objectCollidedWith)
	{
		if(objectCollidedWith.gameObject.tag == "Enemy")
		{
			playerMovementScript.SwapPlayerState();
			GameObject enemy = objectCollidedWith.gameObject;
			battleManagerScript.BattleStart(enemy);
		}
	}
}
