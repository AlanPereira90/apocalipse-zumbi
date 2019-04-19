using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel {
	
	public LayerMask MascaraChao;
	public ControlaInterface controlaInterface;
	public AudioClip SomDeDano;

	private Vector3 direcao;
	private MovimentoJogador movimentoJogador;
	private AnimacaoPersonagem animacaoJogador;
	public Status statusJogador;

	private void Start() {		
		movimentoJogador = GetComponent<MovimentoJogador>();
		animacaoJogador = GetComponent<AnimacaoPersonagem>();
		statusJogador = GetComponent<Status>();
	}

	// Update is called once per frame
	void Update () {

		float eixoX = Input.GetAxis("Horizontal");
		float eixoZ = Input.GetAxis("Vertical");

		direcao = new Vector3(eixoX,0,eixoZ);		

		animacaoJogador.AnimarMovimento(direcao);		
	}

	void FixedUpdate() {

		movimentoJogador.Movimentar(direcao, statusJogador.Velocidade);			
		movimentoJogador.RotacionarJogador(MascaraChao);
	}

	public void TomarDano(int dano){

		statusJogador.Vida -= dano;
		controlaInterface.AtualizaVidaJogador();
		ControlaAudio.instancia.PlayOneShot(SomDeDano);
		if (statusJogador.Vida <= 0){
			Morrer();
		}
	}

	public void Morrer(){
		controlaInterface.GameOver();
	}
}
