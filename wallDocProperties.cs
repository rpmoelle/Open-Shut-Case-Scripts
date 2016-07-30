using UnityEngine;
using System.Collections;

public class wallDocProperties : MonoBehaviour {
    public bool beenPlaced = false;
    public bool onWallNow = false;
    public bool read = false;
    public string subtitle;
    public string tempSub = "Press Space to Examine and Click to Grab";

    public Texture icon;
    public Texture fullImage;

    public bool inYourFavor;

    string getSub()
    {
        //determine this documents unique subtitle
        return subtitle;
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        //check if player examined the document
        if (read)
        {
            //Change subtitle based on name of gameobj
            subtitle = getSub();
        }
	}
}
