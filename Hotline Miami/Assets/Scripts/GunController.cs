using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponController {

	public GameObject bullet;
	public float speed;
	public int ammo;


	public override void attack(Vector2 bullet_dir)
	{
		
		if (ammo > 0) {
			bullet_dir.Normalize ();
			bullet_dir = new Vector2 (-bullet_dir.x, -bullet_dir.y);
			GameObject tmp = Instantiate (bullet, (transform.position + new Vector3(bullet_dir.x,bullet_dir.y , 0)), Quaternion.identity);
			tmp.GetComponent<Rigidbody2D> ().velocity = bullet_dir * speed;

			/*Vector3 mouseDelta = Camera.main.WorldToScreenPoint(worldPoint) - Camera.main.WorldToScreenPoint(tmp.transform.position);

			if (mouseDelta.sqrMagnitude < 0.1f)
			{
				return; // don't do tiny rotations.
			}


			float angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
			if (angle<0) angle += 360;

			tmp.transform.Rotate ((Vector3.forward * angle));*/
			float angle = Mathf.Atan2 (bullet_dir.y, bullet_dir.x) * Mathf.Rad2Deg;
			if (angle<0) angle += 360;
			tmp.transform.Rotate ((Vector3.forward * angle));
			ammo--;
		}
	}
}
