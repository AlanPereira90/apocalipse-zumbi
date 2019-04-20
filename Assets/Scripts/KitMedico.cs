using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour {

	private int quantidadeCura = 10;
	private float tempoDestruir = 5;

	private void Start() {
		Destroy(gameObject, tempoDestruir);
	}

	private void OnTriggerEnter(Collider objetoDeColisao) {
		
		if (objetoDeColisao.tag == "Jogador"){

			objetoDeColisao.GetComponent<ControlaJogador>().CurarVida(quantidadeCura);
			Destroy(gameObject);
		}
	}
}
