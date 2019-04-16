using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour {

	public Slider SliderVidaJogador;
	private ControlaJogador controlaJogador;

	// Use this for initialization
	void Start () {
		
		controlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();

		SliderVidaJogador.maxValue = controlaJogador.statusJogador.Vida;
		AtualizaVidaJogador();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AtualizaVidaJogador(){
		SliderVidaJogador.value = controlaJogador.statusJogador.Vida;
	}
}
