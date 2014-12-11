using UnityEngine;
using System.Collections;

public class PlayerBattleStatus : MonoBehaviour
{
	public int health;
	public int totalHealth;
	public int maxHealth;
	public int attack;
	public int totalAttack;
	public int energy;
	public int totalEnergy;
	public int stamina;

	// Use this for initialization
	void Start () 
	{
		health = 20;
		maxHealth = health*(2);
		attack = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public int PlayerTakenDamage(int enemyAttackDamage)
	{
		health -= enemyAttackDamage;
		return health;
	}
}
