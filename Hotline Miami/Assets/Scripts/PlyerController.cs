using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerController : HumanContller {

	void Update()
	{
		float h = Input.GetAxis ("Vertical");
		float w = Input.GetAxis ("Horizontal");
		move (new Vector2 (w, h));
	}
}
