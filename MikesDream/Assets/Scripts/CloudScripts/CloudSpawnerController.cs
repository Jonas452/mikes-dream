using UnityEngine;
using System.Collections;

public class CloudSpawnerController : MonoBehaviour 
{

	public GameObject cloud01Prefab;
	public GameObject cloud02Prefab;
	public GameObject cloud03Prefab;

	public GameObject gameController;
	private GameControllerScript gameControllerScript;

	void Start () 
	{
	
		gameControllerScript = gameObject.GetComponent<GameControllerScript>();

	}
		
	public void SpawnCloud()
	{

		if( gameControllerScript.isPlayerAlive )
		{
			
			GameObject cloud;

			switch( (int) Random.Range (1f, 3f ) )
			{
			case 1:
				cloud = GameObject.Instantiate (cloud01Prefab) as GameObject;
				break;
			case 2:
				cloud = GameObject.Instantiate (cloud02Prefab) as GameObject;
				break;
			case 3:
				cloud = GameObject.Instantiate (cloud03Prefab) as GameObject;
				break;
			default:
				cloud = GameObject.Instantiate (cloud01Prefab) as GameObject;
				break;			
			}

			cloud.transform.position = transform.position - ( Random.Range( -5f, -2f ) * Vector3.up );


			Invoke( "SpawnCloud", Random.Range( 2f, 4f ) ); 

		}

	}

}