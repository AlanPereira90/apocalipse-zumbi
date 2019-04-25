using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	public float VidaInicial = 100;
	[HideInInspector]
	public float Vida;
	public float Velocidade = 10;
	public float AlcanceVisao = 15;
	public float AlcanceAtaque = 2.6f;
	[HideInInspector]
	public bool Vivo;
    public int DanoMinimo = 1;
	public int DanoMaximo = 20;

	private void Awake() {
		Vida = VidaInicial;
		Vivo = true;
	}

	private void Update() {
		Vivo = (Vida > 0);
	}
}
