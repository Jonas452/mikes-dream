using UnityEngine;
using System.Collections;

public class MikeController : MonoBehaviour 
{

	public AudioClip powerUp, powerDown, jump;

	AudioSource audio;

	[SerializeField] private float m_JumpForce = 350f;
	[SerializeField] private LayerMask m_WhatIsGround;

	private Transform m_GroundCheck;
	const float k_GroundedRadius = 1f;

	private bool m_Grounded;

	private Animator m_Anim;
	private Rigidbody2D m_Rigidbody2D;

	private bool small = false;

	void Awake() 
	{

		audio = GetComponent<AudioSource>();
		m_GroundCheck = transform.Find( "GroundCheck" );
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Anim = GetComponent<Animator>();

	}

	void FixedUpdate()
	{

		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll( m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround );

		for( int i = 0; i < colliders.Length; i++ )
		{

			if( colliders[i].gameObject != gameObject )
			{

				m_Grounded = true;

			}

		}

		m_Anim.SetBool( "Ground", m_Grounded );

	}

	public void Jump()
	{

		if( !small && m_Grounded ) 
		{
			
			m_Anim.SetBool ("Ground", false);
			m_Grounded = false;
			m_Rigidbody2D.AddForce( new Vector2 ( 0f, m_JumpForce ) );
			audio.PlayOneShot( jump );

		}

	}

	public void Evade()
	{

		if( m_Grounded )
		{

			small = !small;

			if( !small )
			{

				audio.PlayOneShot( powerUp );
				transform.localScale = new Vector2( 2f, 2f );
				
			}else
			{

				audio.PlayOneShot( powerDown );
				transform.localScale = new Vector2( 1f, 1f );
				
			}

		}

	}

}