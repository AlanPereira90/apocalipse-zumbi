using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	public float VidaInicial = 100;
	[HideInInspector]
	public float Vida;
	public float Velocidade = 10;
	public float AlcanceVisao = 15;
	public float AlcanceAtaque = 2.5f;

	private void Awake() {
		Vida = VidaInicial;
	}
}
