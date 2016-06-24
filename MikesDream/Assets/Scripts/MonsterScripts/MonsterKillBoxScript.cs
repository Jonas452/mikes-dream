using UnityEngine;
using System.Collections;

public class MonsterKillBoxScript : MonoBehaviour 
{

	private GameObject gameController;

	void Awake () 
	{

		gameController = GameObject.FindGameObjectWithTag ("GameController" );

	}


	void OnTriggerEnter2D( Collider2D col )
	{

		if( col.CompareTag( "Player" ) )
		{
			
			gameController.SendMessage( "PlayerDied" );

		}else if( col.CompareTag("Wall") )
		{

			Destroy ( gameObject.transform.parent.gameObject );

		}

	}

}