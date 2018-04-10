using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterActivator : MonoBehaviour {
	
    public enum ForceType
    {
        Slash,
        Pierce
    }

    public int numberOfSplats = 10;
	public float minSplatRange = 7f;
	public float maxSplatRange = 12f;
    public float velocity = 10f;
    public ForceType forceType = ForceType.Pierce;
    private SplatterTarget target;

    void OnCollisionEnter(Collision other)
    {
        target = other.collider.GetComponent<SplatterTarget>();
        if (target != null) {
            target.Bleed(this, other);
        }
    }
}
