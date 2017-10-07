using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject inHand;

	public virtual void attack (Vector2 attack_dir){
	}

	public GameObject pickUp()
	{
		
		return inHand;

	}

	public void equip()
	{
		GetComponent<Renderer> ().enabled = false;
		gameObject.SetActive (false);
	}

	public void unEquip(Vector3 start, Vector3 end){
		GetComponent<Renderer> ().enabled = true;
		gameObject.SetActive (true);
		transform.position = start;
		IEnumerator cor = drop (end);
		StartCoroutine(cor);
	}

	IEnumerator drop(Vector3 end) {
		while (transform.position != end) {
			Vector3 move = end - transform.position;
			move.Normalize ();
			move = move * (0.5f * Time.deltaTime);
			transform.Translate (move);
			yield return null;
		}
	}

}
