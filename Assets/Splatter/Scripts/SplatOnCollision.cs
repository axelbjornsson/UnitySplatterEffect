using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatOnCollision : MonoBehaviour {

	public ParticleSystem particleLauncher;
	public Gradient particleColorGradient;
	public ParticleDecalPool dropletDecalPool;

	List<ParticleCollisionEvent> collisionEvents;


	void Start () 
	{
		collisionEvents = new List<ParticleCollisionEvent> ();
		var x = particleLauncher.main; 
		x.startColor = particleColorGradient.Evaluate(Random.Range(0f,1f));

	}

	void OnParticleCollision(GameObject other)
	{
		int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents (particleLauncher, other, collisionEvents);
		for (int i = 0; i < numCollisionEvents; i++)
		{	
            dropletDecalPool.ParticleHit(new ContactData(collisionEvents[i]), particleColorGradient);
		}
	}

}
