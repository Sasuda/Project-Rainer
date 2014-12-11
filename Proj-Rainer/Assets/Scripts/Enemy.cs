using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public int health;
	public int attack;
	public int energy;
	public int stamina;
	public int exp;

	// Use this for initialization
	void Start () 
	{
		health = 5;
		attack = 1;
		exp = 15;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void EnemyDefeated()
	{
		DestroyObject(this.gameObject);
	}
}
