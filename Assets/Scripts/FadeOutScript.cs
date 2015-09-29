using UnityEngine;
using System.Collections;

public class FadeOutScript : MonoBehaviour {

	public CanvasGroup fadable;
	public bool fade = false;
	public CanvasChanger SceneLogic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fade) {
			fadable.alpha -= Time.deltaTime * 1;
		}
		if (fadable.alpha <= 0) {
			SceneLogic.Activate("desk");
			SceneLogic.Activate("nextUp");
			this.gameObject.SetActive (false);
		}

	}

	public void FadeOutAndShutDown(){
		fade = true;
	}
}
