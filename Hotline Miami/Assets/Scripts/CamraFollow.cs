using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraFollow : MonoBehaviour {
	public GameObject target;
	public float zOffset = -10;
	
	// Update is called once per frame
	void Update () {
		if (target)
			transform.position = target.transform.position + new Vector3 (0, 0, zOffset);
	}
}
