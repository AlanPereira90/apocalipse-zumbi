using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour {

	public Slider SliderVidaJogador;
	public GameObject PainelGameOver;
	public Text TextoTempoDeSobrevivencia;
	public Text TextoRecorde;
	public Text TextoZumbisMortos;
	private ControlaJogador controlaJogador;
	private float tempoSalvo;
	private int quantidadeZumbisMortos;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		tempoSalvo = PlayerPrefs.GetFloat("TempoRecorde");
		controlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
		SliderVidaJogador.maxValue = controlaJogador.statusJogador.Vida;
		AtualizaVidaJogador();
	}

	public void AtualizaVidaJogador(){
		SliderVidaJogador.value = controlaJogador.statusJogador.Vida;
	}

	public void GameOver(){
		Time.timeScale = 0;
		PainelGameOver.SetActive(true);

		int minutos = (int)(Time.timeSinceLevelLoad / 60);
		int segundos = (int)(Time.timeSinceLevelLoad % 60);
		TextoTempoDeSobrevivencia.text = "Você sobreviveu por " + minutos + "min e " + segundos + "s";

		AjustaPontuacaoMaxima(minutos,segundos);
	}

	void AjustaPontuacaoMaxima(int min, int seg){

		if (Time.timeSinceLevelLoad > tempoSalvo){
			tempoSalvo = Time.timeSinceLevelLoad;			
			PlayerPrefs.SetFloat("TempoRecorde",tempoSalvo);
		}
		else
		{
			min = (int)(tempoSalvo / 60);
			seg = (int)(tempoSalvo % 60);
		}

		TextoRecorde.text = "Seu melhor tempo é " + min + "m e " + seg + "s";
	}

	public void Reiniciar(){
		Time.timeScale = 1;	
		SceneManager.LoadScene("game");
	}

	public void IncrementaZumbisMortos(){
		quantidadeZumbisMortos++;
		TextoZumbisMortos.text = "X " + quantidadeZumbisMortos;
	}
}
