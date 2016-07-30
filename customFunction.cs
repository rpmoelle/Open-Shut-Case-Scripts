using UnityEngine;
using System.Collections;

public class customFunction : MonoBehaviour {

	public GameObject player;
	public string lookForOption;
	
	void Start () {
		//fill this with stuff you want to initialize with
	}
	

	void Update () {
		player = GameObject.Find ("Player");

		//if the current dialogue's node title is the same as the phrase you put in Look For Option, do something
		if (player.GetComponent<Dialogue> ().lastNodeTitle.Equals(lookForOption)) {
			Debug.Log("I'm doing the thing!!");
			//write your functions here
			destroySelf();
		}
	}

	//an example of a function
	public void destroySelf()
	{
		Destroy (gameObject);
	}
}
