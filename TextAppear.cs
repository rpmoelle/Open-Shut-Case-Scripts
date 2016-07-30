using UnityEngine;
using System.Collections;

public class TextAppear : MonoBehaviour {
	public bool showText = false;
	public GameObject player;
	private float distance;
	public string message = "Please replace this text";
	public GUIStyle colorStyle;
	public TextAsset npcDialogue;
	public bool canShow = false;
	
	void Update()
	{
		player = GameObject.Find ("Player");
		distance = Vector3.Distance (player.transform.position, this.transform.position);
		//if the distance is larger than 2, don't let the player see text associated with objects
		if (distance >= 2) {
			canShow = false;
		}
		//if you CAN see the text, press this to start the dialogue conversation
		if (Input.GetKeyDown (KeyCode.E) && canShow) {
			if (!player.GetComponent<Dialogue>().running) {
				showText = true;
			}
		}

		if (showText && (!player.GetComponent<Dialogue> ().running)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			canShow = false;
			player.GetComponent<Dialogue> ().Run (npcDialogue);

			if (!player.GetComponent<Dialogue> ().running) {
				showText = false;
			}
		} else {
			showText = false;
		}

	}

	void OnGUI()
	{
		//the thing that tells the player they can have dialogue with the object
		if (canShow == true) {
			GUI.Label(new Rect(Screen.width*.125f, Screen.height*.75f, Screen.width*.75f, Screen.height*.25f), "Press E", colorStyle);
		}

		//if you want text to show up without input, use the code below. The text shown is the phrase you type into Message in the inspector
		/*if(showText)
		{
			//GUI.Label(new Rect(Screen.width*.125f, Screen.height*.75f, Screen.width*.75f, Screen.height*.25f), message, colorStyle);


			//if(GUI.Button(new Rect(100,100,100,20), "Click To Close"))

			if(Input.GetMouseButtonUp (0)) {
				showText = false;
			}
		}*/
	}
}
