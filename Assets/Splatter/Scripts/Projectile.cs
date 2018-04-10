using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed = 20f;
	
	// Update is called once per frame
	void Update () {
		//transform.position = (transform.position + transform.forward * speed * Time.deltaTime);
		this.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}
}
