using UnityEngine;
using System.Collections;

public class JumpingModel : MonoBehaviour {
	
	public float jumpPower = 7.0f;
	public float minCooldown = 1.0f;
	public float maxCooldown = 3.0f;
	public float randomnessJump = 3.0f;
	
	private float cooldown;
	private bool isJumping = false;
	
	void Start () 
	{
		if(!gameObject.GetComponent<Rigidbody>())
		{
			Debug.LogWarning("This object has no rigid body! can't jump!!");	
		}
		else
		{
			
			Rigidbody temp;
			temp = gameObject.GetComponent<Rigidbody>();
			temp.constraints = temp.constraints | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			temp.constraints &= ~RigidbodyConstraints.FreezeRotationY;
			temp.useGravity = true;			
			cooldown = Random.Range(minCooldown, maxCooldown);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.deltaTime;	
		if(cooldown <= 0 && !isJumping)
		{		
			Jump();
			isJumping = true;
		}

	}
	
	void Jump()
	{
		
		gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpPower + Random.Range(-randomnessJump,randomnessJump)), ForceMode.Impulse);
	}
	
	bool IsGrounded()
	{
		return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f, collider.bounds.center.z), 10f);
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Floor")
		{
			isJumping = false;	
			cooldown = Random.Range(minCooldown, maxCooldown);;
		}
	}

}
