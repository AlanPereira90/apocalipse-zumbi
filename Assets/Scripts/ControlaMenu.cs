using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour {

	void MudarCena (string nomeDaCena){     
		SceneManager.LoadScene(nomeDaCena);
	}

	public void JogarJogo (){
		MudarCena("game");
	}
}
