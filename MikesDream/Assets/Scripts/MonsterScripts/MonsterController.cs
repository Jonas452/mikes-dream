using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour 
{
	
	public float speed = 0.08f;  

	void Update () 
	{

		this.transform.position += Vector3.left * speed;

	}

}