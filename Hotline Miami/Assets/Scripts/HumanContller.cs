using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanContller : MonoBehaviour {
	[SerializeField]
	private float _speed;
	public float ShowFps
	{
		get { return _speed; }
		set
		{_speed = value; }
	}

	private Rigidbody2D rb2d;
	private Animator	anim;
	private float 		angle;
	protected GameObject equiped = null;
	protected GameObject pickUp = null;
	private WeaponController collectable = null;


	void Awake()
	{
		rb2d = GetComponentInChildren<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
	}

	public void move(Vector2 dir)
	{
		dir.Normalize ();
		if (dir != new Vector2 (0, 0)) {
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}
		rb2d.velocity = dir * _speed;
	}
	public void setRotation(Vector3 targetOnScreen){
		Vector3 mouseDelta = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

		if (mouseDelta.sqrMagnitude < 0.1f)
		{
			return; // don't do tiny rotations.
		}
			

		angle = Mathf.Atan2 (mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
		if (angle<0) angle += 360;
		angle -= transform.rotation.eulerAngles.z - 90;

		transform.Rotate ((Vector3.forward * angle));

	}

	public void equipWeapon(){
		if (pickUp != null && equiped == null) {
			//equiped = Instantiate<GameObject> (pickUp, transform.position , Quaternion.identity);
			equiped = pickUp;
			equiped.transform.position = transform.position;
			equiped.transform.rotation = transform.rotation;
			equiped.transform.parent = transform;
			equiped.transform.localPosition = new Vector3 (-0.246f, -0.134f, 0);
			collectable.equip();
			equiped.SetActive (true);
			pickUp = null;
			Debug.Log ("pickedup gun: "+ equiped.transform.localPosition);
		}
	}

	public void unEquip(Vector3 worldpos){
		if (collectable != null) {
			collectable.unEquip (transform.position, worldpos);
			collectable = null;
			equiped.SetActive (false);
			equiped = null;
			//Destroy (equiped.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Bullet") {
			//this player dies
			Destroy(gameObject);
		} else if (other.tag == "Weapon") {
			//set can pick up gun
			if (equiped == null) {
				collectable = other.GetComponent<WeaponController> ();
				pickUp = collectable.pickUp ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Weapon") {
			//set can pick up gun
			if (equiped == null) {
				collectable = null;
				pickUp = null;
			}
		}
	}


	void OnTriggerExit2d(Collider2D othe){
		pickUp = null;
	}
}
