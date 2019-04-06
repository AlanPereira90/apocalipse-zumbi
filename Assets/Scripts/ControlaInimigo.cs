using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

	public GameObject Jogador;	
	public float Velocidade = 5;

	private Rigidbody rigidgbodyInimigo;
	private Animator animatorInimigo;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag("Jogador");

		rigidgbodyInimigo = GetComponent<Rigidbody>();
		animatorInimigo = GetComponent<Animator>();

		int tipoZumbi = Random.Range(1,28);
		transform.GetChild(tipoZumbi).gameObject.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		Vector3 direcao = Jogador.transform.position - transform.position; 

		float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

		Quaternion novaRotacao = Quaternion.LookRotation(direcao);
		rigidgbodyInimigo.MoveRotation(novaRotacao);

		if (distancia > 2.5){
			GetComponent<Animator>().SetBool("Atacando",false);

		  	rigidgbodyInimigo.MovePosition
		    	(rigidgbodyInimigo.position + (direcao.normalized * Velocidade * Time.deltaTime));			
		}
		else{
			animatorInimigo.SetBool("Atacando",true);
		}
	}

	void AtacaJogador(){
		Time.timeScale = 0;
		Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
		Jogador.GetComponent<ControlaJogador>().Vivo = false;
	}
}
