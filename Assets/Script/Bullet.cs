﻿

// SIMPLIFIED VERSION

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int bulletSpeed = 30; //can be setup for each bullet prefab from the inspector
	public int bulletDirection = 1; //negative is right to left

	void FixedUpdate () {

		//Move the bullet
		GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletDirection*0.1f*bulletSpeed, 0), ForceMode2D.Impulse);

	}


	// When bullet goes out of the screen
	void OnBecameInvisible() {  
		// Destroy the bullet
		Destroy(gameObject);
	}


}