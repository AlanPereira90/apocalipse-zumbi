using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour {

	private Animator animatorPersonagem;

	private void Awake() {
		animatorPersonagem = GetComponent<Animator>();		
	}

	public void Atacar(bool estado){
		animatorPersonagem.SetBool("Atacando",estado);
	}

	public void AnimarMovimento(Vector3 direcao){
		animatorPersonagem.SetFloat("Movendo", direcao.magnitude);
	}
}
