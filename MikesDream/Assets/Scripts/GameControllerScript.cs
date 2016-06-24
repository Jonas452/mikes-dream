using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour 
{

	private int score = 0;

	public Text scoreText;
	public Text lastScore;

	public bool isPlayerAlive;

	public GameObject player;
	private Animator m_Anim;

	public GameObject MenuItems;
	public GameObject playingItems;
	public GameObject CreditsShow;

	void Awake()
	{

		isPlayerAlive = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		m_Anim = player.GetComponent<Animator>();
		m_Anim.SetBool( "isMikeAlive", isPlayerAlive );
		scoreText.text = "Score : " + score.ToString ();

		playingItems.SetActive (false);

	}

	void PlayerScored( int pointsScored )
	{

		if( isPlayerAlive ) 
		{
			
			score += pointsScored;
			scoreText.text = "Score : " + score.ToString ();

		}

	}

	void PlayerDied()
	{

		isPlayerAlive = false;
		destroyAllMonstersAndClouds ();
		m_Anim.SetBool( "isMikeAlive", isPlayerAlive );
		playingItems.SetActive( false );
		lastScore.text = "Last Score : " + score;
		score = 0;
		MenuItems.SetActive( true );

	}

	public void StartGame()
	{

		isPlayerAlive = true;
		m_Anim.SetBool( "isMikeAlive", isPlayerAlive );
		playingItems.SetActive( true );
		MenuItems.SetActive( false );

		scoreText.text = "Score : " + score.ToString ();

		GetComponent<MonsterSpawnerController>().SpawnMonster();
		GetComponent<CloudSpawnerController>().SpawnCloud();

	}

	public void EndGame()
	{

		PlayerDied();

	}

	public void ShowCredits()
	{

		CreditsShow.SetActive( true );
		MenuItems.SetActive( false );

	}

	public void CloseCredits()
	{

		CreditsShow.SetActive( false );
		MenuItems.SetActive( true );

	}

	public void ExitGame()
	{

		Application.Quit();

	}

	private void destroyAllMonstersAndClouds()
	{

		foreach( GameObject monster in GameObject.FindGameObjectsWithTag ("Monster") )
		{
			Destroy( monster );
		}

		foreach( GameObject cloud in GameObject.FindGameObjectsWithTag ("Cloud") )
		{
			Destroy( cloud );
		}

	}
		
}