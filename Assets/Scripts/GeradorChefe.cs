using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour {

	public GameObject Chefe;
	public AudioClip SomCriacao;
	public Transform[] PosicoesPossiveisDeGeracao;

	private float raioDeGeracao = 4;
	public float TempoGerarChefe = 1;
	private float contadorTempo = 0;
	private Transform jogador;

	private void Start() {
		jogador = GameObject.FindWithTag("Jogador").transform;
	}

	private void Update() {
		contadorTempo += Time.deltaTime;

		if (contadorTempo >= TempoGerarChefe){
			NovoChefe();
			contadorTempo = 0;
		}
	}

	void NovoChefe(){
		Instantiate(Chefe, CalcularPosicaoPossivelMaisDistanteDoJogador(), transform.rotation);
		ControlaAudio.instancia.PlayOneShot(SomCriacao);
	}	

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, raioDeGeracao);
	}

	Vector3 CalcularPosicaoPossivelMaisDistanteDoJogador(){
		Vector3 posicaoDeMaiorDistancia = Vector3.zero;
		float maiorDistancia = 0;
		foreach(Transform posicao in PosicoesPossiveisDeGeracao)
		{
			float distanciaPosicaoJogador = Vector3.Distance(jogador.position, posicao.position);
			if(distanciaPosicaoJogador > maiorDistancia)
			{
				maiorDistancia = distanciaPosicaoJogador;
				posicaoDeMaiorDistancia = posicao.position;    
			}
		}
		return posicaoDeMaiorDistancia;
	}
}
