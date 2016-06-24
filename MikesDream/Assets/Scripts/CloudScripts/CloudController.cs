using UnityEngine;
using System.Collections;
      
public class CloudController : MonoBehaviour 
{

	void Update () 
	{

		this.transform.position += Vector3.left * 0.03f;
	
	}

	void OnTriggerEnter2D( Collider2D col )
	{

		if( col.CompareTag("Wall") )
		{

			Destroy ( gameObject );

		}

	}

}