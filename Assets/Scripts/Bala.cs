using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	public float Velocidade = 30;	
	private int danoDoTiro = 1;

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
		
		switch (objetoDeColisao.tag){
			case "Inimigo": objetoDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoDoTiro); break;
			case "Chefe": objetoDeColisao.GetComponent<ControlaChefe>().TomarDano(danoDoTiro); break;			
		}
		Destroy(gameObject);
	}
}
