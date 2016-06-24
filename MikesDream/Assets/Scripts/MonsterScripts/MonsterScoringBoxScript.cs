using UnityEngine;
using System.Collections;

public class MonsterScoringBoxScript : MonoBehaviour 
{

	private GameObject gameController;

	void Awake () 
	{

		gameController = GameObject.FindGameObjectWithTag ("GameController" );

	}

	void OnTriggerExit2D( Collider2D col )
	{

		if( col.CompareTag( "Player" ) )
		{

			gameController.SendMessage( "PlayerScored", 30 );

		}

	}

}