using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel {

	public GameObject Jogador;
	public AudioClip SomDeMorte;
	
	private ControlaJogador controlaJogador;
	private MovimentoPersonagem movimentoInimigo;
	private AnimacaoPersonagem animacaoInimigo;
	private Status statusInimigo;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag("Jogador");
		controlaJogador = Jogador.GetComponent<ControlaJogador>();
		movimentoInimigo = GetComponent<MovimentoPersonagem>();	
		animacaoInimigo = GetComponent<AnimacaoPersonagem>();
		statusInimigo = GetComponent<Status>();
		AleatorizarZumbi();				
	}

	void FixedUpdate() {

		Vector3 direcao = Jogador.transform.position - transform.position; 

		float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

		movimentoInimigo.Rotacionar(direcao);

		if (distancia > 2.5){
			animacaoInimigo.Atacar(false);

		  	movimentoInimigo.Movimentar(direcao, statusInimigo.Velocidade);			
		}
		else{
			animacaoInimigo.Atacar(true);
		}
	}

	void AtacaJogador(){
		int dano = Random.Range(10, 21);
		controlaJogador.TomarDano(dano);
	}

	void AleatorizarZumbi(){
		int tipoZumbi = Random.Range(1,28);
		transform.GetChild(tipoZumbi).gameObject.SetActive(true);
	}

	public void TomarDano(int dano){
		statusInimigo.Vida -= dano;
		if (statusInimigo.Vida <= 0){
			Morrer();
		}
	}

	public void Morrer(){		
		Destroy(gameObject);
		ControlaAudio.instancia.PlayOneShot(SomDeMorte);
	}
}
