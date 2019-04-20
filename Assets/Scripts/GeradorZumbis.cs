using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

	public GameObject Zumbi;
	public float TempoGerarZumbi = 1;
	public LayerMask LayerZumbi;

	private float contadorTempo = 0;
	private float distanciaMinimaParaGerar = 30;
	private float raioDeGeracao = 4;
	private GameObject jogador;

	// Use this for initialization
	void Start () {
		jogador = GameObject.FindWithTag("Jogador");
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaMinimaParaGerar){
			contadorTempo += Time.deltaTime;

			if (contadorTempo >= TempoGerarZumbi){
				StartCoroutine(NovoZumbi());
				contadorTempo = 0;
			}
		}
	}

	IEnumerator NovoZumbi(){
		Vector3 posicaoDeCriacao = PosicaoAleatoria();
		Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);

		while (colisores.Length > 0){
			posicaoDeCriacao = PosicaoAleatoria();
			colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);	
			yield return null;
		}
		Instantiate(Zumbi, transform.position, transform.rotation);
	}

	Vector3 PosicaoAleatoria(){
		Vector3 posicao = Random.insideUnitSphere * raioDeGeracao;
		posicao += transform.position;
		posicao.y = transform.position.y;

		return posicao;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, raioDeGeracao);
	}
}
