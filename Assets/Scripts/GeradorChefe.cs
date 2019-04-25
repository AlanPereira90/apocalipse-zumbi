using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour {

	public GameObject Chefe;
	private float raioDeGeracao = 4;
	public float TempoGerarChefe = 1;
	private float contadorTempo = 0;

	private void Update() {
		contadorTempo += Time.deltaTime;

		if (contadorTempo >= TempoGerarChefe){
			NovoChefe();
			contadorTempo = 0;
		}
	}

	void NovoChefe(){
		Instantiate(Chefe, transform.position, transform.rotation);
		this.enabled = false;
	}	

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, raioDeGeracao);
	}
}
