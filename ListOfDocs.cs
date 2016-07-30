using UnityEngine;

using System.Collections;

using System.Collections.Generic;

public class ListOfDocs : MonoBehaviour {
    //this keeps track of what docs are satanic, insurance, or suicide labelled
    public List<GameObject> satanDocs = new List<GameObject>();
    public List<GameObject> insDocs = new List<GameObject>();
    public List<GameObject> suicideDocs = new List<GameObject>();

    void setSuicideDocs()
    {
        //put all the satan docs in the satan list
        //This is the complete reference list
        //12
        suicideDocs.Add(GameObject.Find("tutorialNote"));
        suicideDocs.Add(GameObject.Find("photoTogether"));
        suicideDocs.Add(GameObject.Find("TinaBullshitNote"));
        suicideDocs.Add(GameObject.Find("Drawing1"));
        suicideDocs.Add(GameObject.Find("BetteSuicideLetter"));
        suicideDocs.Add(GameObject.Find("TinaTellThemSuicide"));
        suicideDocs.Add(GameObject.Find("Drawing2"));
        suicideDocs.Add(GameObject.Find("Drawing3"));
        suicideDocs.Add(GameObject.Find("TranscriptTinaSaysSuicide"));
        suicideDocs.Add(GameObject.Find("Will"));
        suicideDocs.Add(GameObject.Find("BedsideTableContents"));
        suicideDocs.Add(GameObject.Find("VictimPhoto"));



    }

    void setInsDocs()
    {
        //put all the insurance docs in the insurance list
        //This is the complete reference list
        //10
        insDocs.Add(GameObject.Find("bdayCard"));
        insDocs.Add(GameObject.Find("TranscriptTinaLifeInsurance"));
        insDocs.Add(GameObject.Find("GarageList"));
        insDocs.Add(GameObject.Find("Drawing3"));
        insDocs.Add(GameObject.Find("TranscriptTinaSaysSuicide"));
        insDocs.Add(GameObject.Find("TinaWill"));
        insDocs.Add(GameObject.Find("TribuneInsurance"));
        insDocs.Add(GameObject.Find("TranscriptTinaInterview"));
        insDocs.Add(GameObject.Find("TinaShitThingToSay"));
        insDocs.Add(GameObject.Find("closetContents"));

    }

    void setSatanDocs()
    {
        //put all the suicide docs in the suicide list
        //this is the complete reference list
        //11
        satanDocs.Add(GameObject.Find("bdayCard"));
        satanDocs.Add(GameObject.Find("TribuneSatanic"));
        satanDocs.Add(GameObject.Find("Drawing2"));
        satanDocs.Add(GameObject.Find("bedContents"));
        satanDocs.Add(GameObject.Find("closetContents"));//
        satanDocs.Add(GameObject.Find("CoraDesk"));
        satanDocs.Add(GameObject.Find("BetteSatanicLetter"));
        satanDocs.Add(GameObject.Find("Drawing4"));
        satanDocs.Add(GameObject.Find("TranscriptAnsweringMachine"));
        satanDocs.Add(GameObject.Find("Drawing5"));
        satanDocs.Add(GameObject.Find("Drawing6"));


    }
   
    // Use this for initialization
    void Start () {
        setSatanDocs();
        setInsDocs();
        setSuicideDocs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
