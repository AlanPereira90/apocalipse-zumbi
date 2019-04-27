using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControlaChefe : MonoBehaviour, IMatavel {

	public GameObject KitMedico;
	public GameObject ParticulaSangueChefe;
	public AudioClip SomDeMorte;
	public Slider sliderVidaChefe;	

	private Transform jogador;
	private NavMeshAgent agente;
	private Status statusChefe;
    private AnimacaoPersonagem animacaoChefe;
	private MovimentoPersonagem movimentaChefe;
	private ControlaJogador controlaJogador;

	void Start () {
		jogador = GameObject.FindWithTag("Jogador").transform;
		agente = GetComponent<NavMeshAgent>();	
		statusChefe = GetComponent<Status>();
        animacaoChefe = GetComponent<AnimacaoPersonagem>(); 
		movimentaChefe = GetComponent<MovimentoPersonagem>();
		controlaJogador = jogador.GetComponent<ControlaJogador>();

		agente.speed = statusChefe.Velocidade;

		sliderVidaChefe.maxValue = statusChefe.VidaInicial;
		AtualizarInterface();
	}
	
	void Update () {
		agente.SetDestination(jogador.position);
		animacaoChefe.AnimarMovimento(agente.velocity);

		if (agente.hasPath){
			if (agente.remainingDistance <= agente.stoppingDistance){
				Vector3 direcao = jogador.position - transform.position;
        		movimentaChefe.Rotacionar(direcao);

				animacaoChefe.Atacar(true);				
			}
			else{
				animacaoChefe.Atacar(false);
			}
		}
	}

	void AtacaJogador(){
		int dano = Random.Range(statusChefe.DanoMinimo, statusChefe.DanoMaximo);
		controlaJogador.TomarDano(dano);
	}

	public void TomarDano(int dano){
		if (statusChefe.Vivo){
			statusChefe.Vida -= dano;
			AtualizarInterface();
			if (statusChefe.Vida <= 0) {
				Morrer();
			}
		}
	}

	public void Morrer(){		
		ControlaAudio.instancia.PlayOneShot(SomDeMorte);
		animacaoChefe.Morrer();
		Destroy(gameObject,3);	
		GeraKitMedico();
		
		this.enabled = false;	
	}

	void GeraKitMedico(){
		Instantiate(KitMedico, transform.position, Quaternion.identity);
	}

	void AtualizarInterface(){
		sliderVidaChefe.value = statusChefe.Vida;
	}

	public void ParticulaSangue(Vector3 posicao, Quaternion rotacao){
		Instantiate(ParticulaSangueChefe, posicao, rotacao);
	}
}
