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

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
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
}
