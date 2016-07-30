using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class daychange : MonoBehaviour {
    //Put this script on the dayController

    public int dayToChange = 1;
    public bool timeTochange = false;
    public Texture fade;
    bool displayFade;
    List<GameObject> daysDocs;
    public GameObject outs;
    public string ending;
    public bool day8 = false;

    public Sprite day2Sprite;
    public Sprite day3Sprite;
    public Sprite day4Sprite;
    public Sprite day5Sprite;
    public Sprite day6Sprite;
    public Sprite day7Sprite;
    public Sprite day8Sprite;
    public Sprite day9Sprite;

    int fadeTime = 100;

    void deleteWallDocs()
    {
        //This functions deletes all the docs in the game! D:
        //find all the docs on the wall
        GameObject[] all = GameObject.FindGameObjectsWithTag("doc");
        //delete them all!
        foreach(GameObject go in all)
        {
            if (go.GetComponent<wallDocProperties>().onWallNow)
            {
                Destroy(go);
            }
           
        }
    }

    void fadeOut()
    {
        //fade the screen to black
        if(fadeTime > 0)
        {
            fadeTime--;
        }
        
    }

    void fadeIn()
    {
        //fade the screen back in
    }

    void dayIsDone()
    {
        //check if the day is done
        //get the docs in this scene
        //check if all docs are on wall
        foreach(GameObject go in daysDocs)
        {
            if(go != null && !go.GetComponent<wallDocProperties>().onWallNow)
            {
                //if the gameobject hasn't been destroyed and isn't on the wall
                //The Day is not done!
                timeTochange = false;
                return;
            }
            //else all the day's docs are either on the wall or destroyed
            //so day is done!
            GameObject.Find("Player").GetComponent<PickUpDoc>().dayDone = true;

        }
        

    }

    void placeNewDocs()
    {
        //enable the new docs for this day
        //change the tally marks accordingly
        switch (dayToChange)
        {
            //day starts as day 1
            case 1:
                //delete the docs in the day array
                daysDocs.Clear();
                Debug.Log("Cleared thing");
                //add the new day's docs to the array
                GameObject a = GameObject.Find("TinaBullshitNote");
                GameObject b = GameObject.Find("TranscriptTinaLifeInsurance");
                GameObject c = GameObject.Find("TribuneSatanic");
                daysDocs.Add(a);
                daysDocs.Add(b);
                daysDocs.Add(c);
                // enable docs for day 2
                a.GetComponent<SpriteRenderer>().enabled = true;
                a.GetComponent<BoxCollider>().enabled = true;
                a.GetComponent<LineRenderer>().enabled = true;
                //b
                b.GetComponent<SpriteRenderer>().enabled = true;
                b.GetComponent<BoxCollider>().enabled = true;
                b.GetComponent<LineRenderer>().enabled = true;
                //c
                c.GetComponent<SpriteRenderer>().enabled = true;
                c.GetComponent<BoxCollider>().enabled = true;
                c.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 2
                this.GetComponent<SpriteRenderer>().sprite = day2Sprite;
                break;
            case 2:
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject d = GameObject.Find("Drawing1");
                GameObject e = GameObject.Find("BetteSuicideLetter");
                GameObject f = GameObject.Find("GarageList");
                daysDocs.Add(d);
                daysDocs.Add(e);
                daysDocs.Add(f);
                // enable docs for day 3
                d.GetComponent<SpriteRenderer>().enabled = true;
                d.GetComponent<BoxCollider>().enabled = true;
                d.GetComponent<LineRenderer>().enabled = true;
                //e
                e.GetComponent<SpriteRenderer>().enabled = true;
                e.GetComponent<BoxCollider>().enabled = true;
                e.GetComponent<LineRenderer>().enabled = true;
                //f
                f.GetComponent<SpriteRenderer>().enabled = true;
                f.GetComponent<BoxCollider>().enabled = true;
                f.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 3
                this.GetComponent<SpriteRenderer>().sprite = day3Sprite;
                break;
            case 3:
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject g = GameObject.Find("TinaTellThemSuicide");
                GameObject h = GameObject.Find("Drawing2");
                GameObject i = GameObject.Find("bedContents");
                GameObject j = GameObject.Find("Drawing3");
                daysDocs.Add(g);
                daysDocs.Add(h);
                daysDocs.Add(i);
                daysDocs.Add(j);
                // enable docs for day 4
                g.GetComponent<SpriteRenderer>().enabled = true;
                g.GetComponent<BoxCollider>().enabled = true;
                g.GetComponent<LineRenderer>().enabled = true;
                //h
                h.GetComponent<SpriteRenderer>().enabled = true;
                h.GetComponent<BoxCollider>().enabled = true;
                h.GetComponent<LineRenderer>().enabled = true;
                //i
                i.GetComponent<SpriteRenderer>().enabled = true;
                i.GetComponent<BoxCollider>().enabled = true;
                i.GetComponent<LineRenderer>().enabled = true;
                //j
                j.GetComponent<SpriteRenderer>().enabled = true;
                j.GetComponent<BoxCollider>().enabled = true;
                j.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 4
                this.GetComponent<SpriteRenderer>().sprite = day4Sprite;
                break;
            case 4:
                //day 5
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject k = GameObject.Find("TranscriptTinaSaysSuicide");
                GameObject l = GameObject.Find("TinaWill");
                GameObject m = GameObject.Find("Will");
                GameObject n = GameObject.Find("TribuneInsurance");
                daysDocs.Add(k);
                daysDocs.Add(l);
                daysDocs.Add(m);
                daysDocs.Add(n);
                // enable docs for day 5
                k.GetComponent<SpriteRenderer>().enabled = true;
                k.GetComponent<BoxCollider>().enabled = true;
                k.GetComponent<LineRenderer>().enabled = true;
                //l
                l.GetComponent<SpriteRenderer>().enabled = true;
                l.GetComponent<BoxCollider>().enabled = true;
                l.GetComponent<LineRenderer>().enabled = true;
                //m
                m.GetComponent<SpriteRenderer>().enabled = true;
                m.GetComponent<BoxCollider>().enabled = true;
                m.GetComponent<LineRenderer>().enabled = true;
                //n
                n.GetComponent<SpriteRenderer>().enabled = true;
                n.GetComponent<BoxCollider>().enabled = true;
                n.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 5
                this.GetComponent<SpriteRenderer>().sprite = day5Sprite;
                break;
            case 5:
                //day 6
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject o = GameObject.Find("closetContents");
                GameObject p = GameObject.Find("TranscriptTinaInterview");
                GameObject q = GameObject.Find("CoraDesk");
                daysDocs.Add(o);
                daysDocs.Add(p);
                daysDocs.Add(q);
                // enable docs for day 5
                o.GetComponent<SpriteRenderer>().enabled = true;
                o.GetComponent<BoxCollider>().enabled = true;
                o.GetComponent<LineRenderer>().enabled = true;
                //l
                p.GetComponent<SpriteRenderer>().enabled = true;
                p.GetComponent<BoxCollider>().enabled = true;
                p.GetComponent<LineRenderer>().enabled = true;
                //m
                q.GetComponent<SpriteRenderer>().enabled = true;
                q.GetComponent<BoxCollider>().enabled = true;
                q.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 6
                this.GetComponent<SpriteRenderer>().sprite = day6Sprite;
                break;
            case 6:
                //day 7
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject r = GameObject.Find("TinaShitThingToSay");
                GameObject s = GameObject.Find("BetteSatanicLetter");
                GameObject t = GameObject.Find("BedsideTableContents");
                GameObject u = GameObject.Find("Drawing4");
                daysDocs.Add(r);
                daysDocs.Add(s);
                daysDocs.Add(t);
                daysDocs.Add(u);
                // enable docs for day 5
                r.GetComponent<SpriteRenderer>().enabled = true;
                r.GetComponent<BoxCollider>().enabled = true;
                r.GetComponent<LineRenderer>().enabled = true;
                //l
                s.GetComponent<SpriteRenderer>().enabled = true;
                s.GetComponent<BoxCollider>().enabled = true;
                s.GetComponent<LineRenderer>().enabled = true;
                //m
                t.GetComponent<SpriteRenderer>().enabled = true;
                t.GetComponent<BoxCollider>().enabled = true;
                t.GetComponent<LineRenderer>().enabled = true;
                //n
                u.GetComponent<SpriteRenderer>().enabled = true;
                u.GetComponent<BoxCollider>().enabled = true;
                u.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 7
                this.GetComponent<SpriteRenderer>().sprite = day7Sprite;
                break;
            case 7:
                //day 8
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject v = GameObject.Find("TranscriptAnsweringMachine");
                GameObject w = GameObject.Find("Drawing5");
                GameObject x = GameObject.Find("VictimPhoto");
                daysDocs.Add(v);
                daysDocs.Add(w);
                daysDocs.Add(x);
                // enable docs for day 5
                v.GetComponent<SpriteRenderer>().enabled = true;
                v.GetComponent<BoxCollider>().enabled = true;
                v.GetComponent<LineRenderer>().enabled = true;
                //l
                w.GetComponent<SpriteRenderer>().enabled = true;
                w.GetComponent<BoxCollider>().enabled = true;
                w.GetComponent<LineRenderer>().enabled = true;
                //m
                x.GetComponent<SpriteRenderer>().enabled = true;
                x.GetComponent<BoxCollider>().enabled = true;
                x.GetComponent<LineRenderer>().enabled = true;
                //set tally to day 8  
                this.GetComponent<SpriteRenderer>().sprite = day8Sprite;
                break;
            case 8:
                day8 = true;
                //day 9
                daysDocs.Clear();
                //add the new day's docs to the array
                GameObject y = GameObject.Find("Drawing6");
                daysDocs.Add(y);
                // enable docs for day 5
                y.GetComponent<SpriteRenderer>().enabled = true;
                y.GetComponent<BoxCollider>().enabled = true;
                y.GetComponent<LineRenderer>().enabled = true;
                //l
                //set tally to day 9  
                this.GetComponent<SpriteRenderer>().sprite = day9Sprite;
                break;
            case 9:
                //this is the endings
                Debug.Log("ENDING DAY" + outs.GetComponent<outcomes>().gotOutcome);
                if (ending == "satanic")
                {
                    Debug.Log("Satan ENding c");
                    //if satan ending, load satan doc
                    daysDocs.Clear();
                    //add the new day's docs to the array
                    GameObject z = GameObject.Find("SatanEnding");
                    daysDocs.Add(z);
                    // enable docs for day 5
                    z.GetComponent<SpriteRenderer>().enabled = true;
                    z.GetComponent<BoxCollider>().enabled = true;
                    z.GetComponent<LineRenderer>().enabled = true;
                    //set the next day
                    dayToChange++;

                }
                if (ending == "suicide")
                {
                    Debug.Log("Suicide ENding a");
                    //if suicide ending, load suicide doc
                    daysDocs.Clear();
                    //add the new day's docs to the array
                    GameObject zz = GameObject.Find("SuicideEnding");
                    daysDocs.Add(zz);
                    // enable docs for day 5
                    zz.GetComponent<SpriteRenderer>().enabled = true;
                    zz.GetComponent<BoxCollider>().enabled = true;
                    zz.GetComponent<LineRenderer>().enabled = true;
                    //after this, when you go to sleep, game takes you back to the menu
                    //set the next day
                    dayToChange++;
                }
              
                if (ending == "insurance")
                {
                    Debug.Log("ins ENding b");
                    //if insurance ending, load insurance doc
                    //delete other docs, as they have been confiscated
                    deleteWallDocs();

                    daysDocs.Clear();
                    //add the new day's docs to the array
                    GameObject zzz = GameObject.Find("InsEnding");
                    daysDocs.Add(zzz);
                    // enable docs for day 5
                    zzz.GetComponent<SpriteRenderer>().enabled = true;
                    zzz.GetComponent<BoxCollider>().enabled = true;
                    zzz.GetComponent<LineRenderer>().enabled = true;
                    //set the next day
                    dayToChange++;

                }
                timeTochange = false;
                return;
            case 10:
                //you should only get here if you got the suicide ending
                //go back to menu
                Debug.Log("Should go to menu");
                Application.LoadLevel(0);
                return;

        }
        //set the next day
        dayToChange++;
        //done transitioning days
        timeTochange = false;
    }

	// Use this for initialization
	void Start () {
        daysDocs = new List<GameObject>();
        //start with three gameobjects in the array:
        GameObject a = GameObject.Find("tutorialNote");
        daysDocs.Add(a);
        GameObject b = GameObject.Find("bdayCard");
        daysDocs.Add(b);
        GameObject c = GameObject.Find("photoTogether");
        daysDocs.Add(c);


    }

    // Update is called once per frame
    void Update () {
        if (timeTochange)
        {
            // fadeOut();
            //turn screen black for now
            Debug.Log("TIME TO CHANGE");
            displayFade = true;
            placeNewDocs();
            displayFade = false;
        }
        dayIsDone();
	}

    void onGUI()
    {
        if(displayFade){
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade);
        }
    }
}
