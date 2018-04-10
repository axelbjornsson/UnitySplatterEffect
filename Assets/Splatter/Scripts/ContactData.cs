using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactData {
	public Vector3 point;
	public Vector3 normal;
	public Vector3 velocity;

    public ContactData(Vector3 point, Vector3 normal, Vector3 velocity)
    {
        this.point = point;
        this.normal = normal;
        this.velocity = velocity;
    }
    
    public ContactData(ParticleCollisionEvent particleCollisionEvent) 
    {
        this.point = particleCollisionEvent.intersection;
        this.normal = particleCollisionEvent.normal;
        this.velocity = particleCollisionEvent.velocity;
    }

}


