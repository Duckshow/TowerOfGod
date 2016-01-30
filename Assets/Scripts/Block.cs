﻿using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour {

	// public statics
	public static List<Block> AllBlocks = new List<Block>();
	public bool inPlay;
	public float SpawnAngle = 0;
    public GameObject ExplosionPrefab;
    public AudioClip ExplosionClip;

	// publics
	public bool interactable = false;


	void OnEnable(){
		AllBlocks.Add (this);
	}
	void OnDisable(){
		AllBlocks.Remove (this);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        var otherBlock = c.gameObject.GetComponent<Block>();
        var otherRigidBody = c.gameObject.GetComponent<Rigidbody2D>();
        var rigidBody = GetComponent<Rigidbody2D>();
       
        if (otherBlock != null) 
        {
			// do add more sounds!

            if (gameObject.tag == "Block" && otherBlock.tag == "Block" &&  c.relativeVelocity.magnitude > GameManager.Instance.DestroyBlockThreshold)
            {
                var offsetIncrement = transform.lossyScale/2f;
                var numExplosions = 3;
                var startPosition = transform.position - offsetIncrement;
                var offset = Vector3.zero;

                var volume = 1.0f;

                for (int i = 0; i < numExplosions; i++)
                {                    
                    var explosion = Instantiate(ExplosionPrefab, startPosition + offset, Quaternion.identity);
                    AudioManager.Instance.Play(ExplosionClip, volume, volume, 0.95f, 1.05f);
                    Destroy(explosion, 1.0f);

                    volume -= 0.33333f;

                    offset += offsetIncrement;
                }

                Destroy(c.gameObject);
            }     
        }
    }
}
