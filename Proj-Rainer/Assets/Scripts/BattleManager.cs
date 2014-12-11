using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour 
{
	public enum MenuState
	{
		battleStart,
		takingTurns,
		battleFinished,
		nonBattle
	}

	MenuState menuState;

	public int turn;
	public GameObject player;
	public PlayerBattleStatus playerBattleScript;
	public Player playerScript;
	public PlayerMovement playerMovementScript;
	int playerAttack;
	int playerHealth;

	public GameObject enemy;
	public Enemy enemyScript;
	int enemyHealth;
	int enemyAttack;
	int expGained;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerBattleScript = (PlayerBattleStatus)player.GetComponent("PlayerBattleStatus");
		//enemy = GameObject.FindWithTag("Enemy");

		playerScript = (Player)player.GetComponent("Player");
		playerMovementScript = (PlayerMovement)player.GetComponent("PlayerMovement"); 

		playerBattleScript.health = playerScript.health;
		playerBattleScript.stamina = playerScript.stamina;

		menuState = MenuState.nonBattle;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(turn == 0) //player's turn
//		{
//			//wait for player input
//			if(
//		}
	}
	void OnGUI()
	{
		if(menuState != MenuState.nonBattle)
		{
			// make a background box
			GUI.Box(new Rect((Screen.width-600)/2 ,
			                 (Screen.height-580)/2,
			                 600, 580), "Battle");
			if(menuState == MenuState.battleStart)
			{
				GUI.Label(new Rect((Screen.width - 380) /2, (Screen.height - 250)/2, 380, 100), "Number of Enemies " + 1);
				// blah blah blah blah blah blah button something so
				if (GUI.Button(new Rect((Screen.width - 380) /2, (Screen.height - 500)/2, 380, 100), "Start"))
				{
					menuState = MenuState.takingTurns;
				}
			}
			else if(menuState == MenuState.takingTurns)
			{
				if(turn == 0) //player's turn
				{
					playerHealth = playerBattleScript.health;
					playerAttack = playerBattleScript.attack;
					enemyAttack = enemyScript.attack; // for status effects etc.
					enemyHealth = enemyScript.health;

					//wait for player input
					if (GUI.Button(new Rect((Screen.width - 380) /2, (Screen.height - 500)/2, 380, 100), "Attack"))
					{
						// method will be here
						enemyHealth -= playerAttack;
						enemyScript.health = enemyHealth;

						if(enemyHealth == 0)
						{
							menuState = MenuState.battleFinished;
						}

						//switch turns
						turn = 1;
					}
					// options button
					if (GUI.Button(new Rect((Screen.width - 380) /2, (Screen.height - 250)/2, 380, 100), "Run"))
					{

					}
				}
				//AI turn(s)
				else if(turn == 1) // temporarily enemy only
				{
					enemyAttack = enemyScript.attack;
					// method AIturn

					//temporary attack simulation
					playerHealth -= enemyAttack;
					playerBattleScript.health = playerHealth;


					//switch turns
					turn = 0;
				}
			}
			else if(menuState == MenuState.battleFinished)
			{
				expGained = enemyScript.exp;
				GUI.Label(new Rect((Screen.width - 380) /2, (Screen.height - 250)/2, 380, 100), "EXP Gained " + expGained);
				// blah blah blah blah blah blah button something so
				if (GUI.Button(new Rect((Screen.width - 380) /2, (Screen.height - 500)/2, 380, 100), "Finished"))
				{
					enemyScript.EnemyDefeated();
					playerMovementScript.SwapPlayerState();
					menuState = MenuState.nonBattle;
				}
	//			// options button
	//			if (GUI.Button(new Rect((Screen.width - 380) /2, (Screen.height - 250)/2, 380, 100), "Back"))
	//			{
	//				menuState = MenuState.main;
	//				//Application.LoadLevel("Main Level");
	//			}
			}
			GUI.Box(new Rect(10, 100, 175f, 80), "");
			GUI.Label(new Rect(10, 100, 200, 20), "HUD");
			GUI.Label(new Rect(10, 120, 200, 20), "Health = " + playerHealth);
			GUI.Label(new Rect(10, 140, 200, 20), "Enemy Health= " + enemyHealth);
			//GUI.Label(new Rect(10, 160, 200, 20), "Enemies Destroyed = " + playerScore);
		}
	}

	public void BattleStart(GameObject triggeredEnemy)
	{
		enemy = triggeredEnemy;
		enemyScript = (Enemy)enemy.GetComponent("Enemy");
		menuState = MenuState.battleStart;
	}

}

// (Input.GetKey("left shift") 
