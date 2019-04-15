using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	public float Velocidade = 30;
	public AudioClip SomDeMorte;

	private Rigidbody rigidBodyBala;

	private void Start() {

		rigidBodyBala = GetComponent<Rigidbody>();
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		rigidBodyBala.MovePosition
		  (rigidBodyBala.position + (transform.forward * Velocidade * Time.deltaTime));

	}

	private void OnTriggerEnter(Collider objetoDeColisao) {
		
		if (objetoDeColisao.tag == "Inimigo"){
			Destroy(objetoDeColisao.gameObject);
			ControlaAudio.instancia.PlayOneShot(SomDeMorte);
		}
		Destroy(gameObject);
	}
}
