using UnityEngine;
using System.Collections;

public class MonsterSpawnerController : MonoBehaviour 
{

	public GameObject FireBallPrefab;
	public GameObject BugPrefab;

	public GameObject gameController;
	private GameControllerScript gameControllerScript;

	void Start () 
	{
	
		gameControllerScript = gameObject.GetComponent<GameControllerScript>();

	}

	public void SpawnMonster()
	{
		
		if( gameControllerScript.isPlayerAlive )
		{
			
			GameObject monster;

			switch( (int) Random.Range (1f, 3f ) )
			{

				case 1:
					monster = GameObject.Instantiate (FireBallPrefab) as GameObject;
					monster.transform.position = transform.position - ( 0.5f * Vector3.up );
					break; 
				case 2:
					monster = GameObject.Instantiate (BugPrefab) as GameObject;
					monster.transform.position = transform.position - ( 1.8f * Vector3.up );
					break;

			}

			Invoke( "SpawnMonster", 2f ); 

		}

	}

}