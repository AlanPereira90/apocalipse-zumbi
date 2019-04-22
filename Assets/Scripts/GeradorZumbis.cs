using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

	public GameObject Zumbi;
	public float TempoGerarZumbi = 1;
	public LayerMask LayerZumbi;
	public ControlaInterface controlaInterface;

	private float contadorTempo = 0;
	private float distanciaMinimaParaGerar = 30;
	private float raioDeGeracao = 4;
	private int quantidadeMaximaZumbisVivos = 2;
	public int QuantidadeZumbisVivos = 0;

	private int zumbisMortosParaAumentoDeDificuldade = 10;
	private int zumbisMortosProximoAumentoDeDificuldade = 10;

	private GameObject jogador;

	// Use this for initialization
	void Start () {
		jogador = GameObject.FindWithTag("Jogador");

		for (int i = 0; i < quantidadeMaximaZumbisVivos; i++) {
			StartCoroutine(NovoZumbi());
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaMinimaParaGerar){
			contadorTempo += Time.deltaTime;

			if ((contadorTempo >= TempoGerarZumbi) && (QuantidadeZumbisVivos < quantidadeMaximaZumbisVivos)){
				StartCoroutine(NovoZumbi());
				contadorTempo = 0;
			}
		}
		VerificaAumentoDeDificuldade();
	}

	void VerificaAumentoDeDificuldade(){
		if (controlaInterface.quantidadeZumbisMortos >= zumbisMortosProximoAumentoDeDificuldade){
			quantidadeMaximaZumbisVivos++;
			zumbisMortosProximoAumentoDeDificuldade = controlaInterface.quantidadeZumbisMortos + zumbisMortosParaAumentoDeDificuldade;
		}
	}

	IEnumerator NovoZumbi(){
		Vector3 posicaoDeCriacao = PosicaoAleatoria();
		Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 2, LayerZumbi);

		while (colisores.Length > 0){
			posicaoDeCriacao = PosicaoAleatoria();
			colisores = Physics.OverlapSphere(posicaoDeCriacao, 2, LayerZumbi);	
			yield return null;
		}
		ControlaInimigo zumbi = Instantiate(Zumbi, transform.position, transform.rotation).GetComponent<ControlaInimigo>();
		zumbi.meuGerador = this;

		IncrementaZumbisVivos();
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

	void IncrementaZumbisVivos(){
		QuantidadeZumbisVivos++;
	}

	public void DecrementaZumbisVivos(){
		QuantidadeZumbisVivos--;
	}
}
