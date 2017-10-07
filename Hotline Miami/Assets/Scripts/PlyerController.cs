using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerController : HumanContller {
	Vector3 oldmouse = new Vector3(0,0,0);
	void Update()
	{
		float h = Input.GetAxis ("Vertical");
		float w = Input.GetAxis ("Horizontal");
		move (new Vector2 (w, h));
		Vector3 mouseOnSceen = Input.mousePosition;
		Camera tmp = Camera.main;
		Vector3 mousepos =  mouseOnSceen;
		if (mousepos != oldmouse) {
			oldmouse = mousepos;
			setRotation (mousepos);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			equipWeapon ();

		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Vector2 bullet_dir =  Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition;

			equiped.GetComponent<WeaponController>(). attack (bullet_dir);
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			Vector3 end =  Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			end.z = 0;
			end.Normalize ();
			end += transform.position;
			base.unEquip (end);
			
		}
	}
}
