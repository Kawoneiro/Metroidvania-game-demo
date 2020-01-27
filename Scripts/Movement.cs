using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;                          
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;  
	[SerializeField]private bool AirControl = false;                         
	[SerializeField] private LayerMask WhatIsGround;                          
	[SerializeField] private Transform GroundCheck;                           

	const float GroundedRadius = .2f; 
	private bool Grounded;            
	private Rigidbody2D Rigidbody2D;
	private bool FacingRight = true;  
	private Vector2 Velocity = Vector2.zero;

	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}
	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}
	public void Move(float move, bool jump)
	{
		if (Grounded || AirControl)
		{
			Vector2 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
			Rigidbody2D.velocity = Vector2.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
		}
		if (Grounded && jump)
		{
			Grounded = false;
			Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
		}
	}


	private void Flip()
	{
		FacingRight = !FacingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

