﻿using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour {

	// public statics
	public static List<Block> AllBlocks = new List<Block>();
	public bool inPlay;

	// publics
	public bool interactable = false;


	void OnEnable(){
		AllBlocks.Add (this);
	}
	void OnDisable(){
		AllBlocks.Remove (this);
	}
}
