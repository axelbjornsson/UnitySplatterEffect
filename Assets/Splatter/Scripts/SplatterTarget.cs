using UnityEngine;

public class SplatterTarget : MonoBehaviour
{
    public Gradient particleColorGradient;
    public ParticleSystem splatterParticles;
	public ParticleDecalPool splatDecalPool;
    private SplatterActivator activator;

    public void Bleed(SplatterActivator activator, Collision collision) {
        this.activator = activator;
        Vector3 velocity;

        int midLength = collision.contacts.Length / 2;
        if (activator.forceType == SplatterActivator.ForceType.Pierce) {
            velocity = activator.transform.forward;
        }
        else {
            var position = this.transform.position;
            position.y = collision.contacts[midLength].point.y;
            velocity =  position - collision.contacts[midLength].point;
        }
        EmitAtLocation(new ContactData(collision.contacts[midLength].point, collision.contacts[midLength].normal, velocity));
    }

    private void EmitAtLocation(ContactData contact)
    {	
		splatterParticles.transform.position = contact.point;
		Vector3 reflection = contact.velocity - 2*(Vector3.Dot(contact.velocity, contact.normal.normalized) * contact.normal.normalized);
		splatterParticles.transform.rotation = Quaternion.LookRotation(reflection);
		ParticleSystem.MainModule psMain = splatterParticles.main;
		psMain.startSpeed = 2;
		splatterParticles.Emit(activator.numberOfSplats);
		splatterParticles.transform.rotation = Quaternion.LookRotation(contact.velocity);
		psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f,1f));
		
        for(int i = 0; i< activator.numberOfSplats; i++)
        {
			psMain.startSpeed = Random.Range(activator.minSplatRange, activator.maxSplatRange);
			splatterParticles.Emit(1);
		}
	}
	
}