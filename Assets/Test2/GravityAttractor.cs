using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

	public float gravity = -9.8f;
	public float gravityRadius = 10f;
	GameObject player;
	public Vector3 playerDirection;
	public Quaternion targetRotation;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	public void Attract(Rigidbody body) {

		float distance = Vector3.Distance (player.transform.position, this.transform.position);

		playerDirection = (this.transform.position - player.transform.position).normalized;

		if ( distance < gravityRadius)
			{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.transform.up;

		// Apply downwards gravity to body
		body.AddForce(gravityUp * gravity);
		// Allign bodies up axis with the centre of planet
		body.rotation = (Quaternion.FromToRotation(localUp,gravityUp) * body.rotation);
		//Smooth the rotation
			body.rotation = Quaternion.Lerp(player.transform.rotation, body.rotation, Time.deltaTime * 3);
			}
	}  

			void OnDrawGizmos ()
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere (this.transform.position, gravityRadius);
			}
}