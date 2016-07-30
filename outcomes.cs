using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class outcomes : MonoBehaviour {
    public bool checkIfDone;
    public bool done;
    public bool checkWall;
    public int numDocs;
    public string finalDisplay= "";
    public GameObject dayChanger;
    public bool lastSleep = false;
    public bool gotOutcome = false;

    public GameObject listOfDocs;

    int getSatanicConnections()
    {
        //return the number of satanic docs that are connected to other satanic docs
        int tally = 0;
        //get all the satanic docs and put them in an array: there are 11 satan docs
        List<GameObject> allSatanDocs = listOfDocs.GetComponent<ListOfDocs>().satanDocs;
        //copy that array into one of existing docs, and one to check against
        List<GameObject> existingSatanDocs = new List<GameObject>();
        //check the array for docs that were thrown out
        foreach(GameObject go in allSatanDocs)
        {
            if(go != null)
            {
                //if doc has not been deleted,
                //add it to existing docs array
                existingSatanDocs.Add(go);
            }
        }

        //go through the array and see what docs are connected to what
        List<GameObject> satanConns = new List<GameObject>();
        for (int i = 0; i < existingSatanDocs.Count; i++)
        {
            //if that doc is connected to another satanic doc, add one to the tally
            if(allSatanDocs.Contains(existingSatanDocs[i].GetComponent<lines>().close))
            {
                tally++;
            }
           
        }
        //when done, return the tally
        return tally;
    }

    int getInsConnections()
    {
        //return the number of insurance docs that are connected to other satanic docs
        int tally = 0;
        //get all the satanic docs and put them in an array: there are 11 satan docs
        List<GameObject> allInsDocs = listOfDocs.GetComponent<ListOfDocs>().insDocs;
        //copy that array into one of existing docs, and one to check against
        List<GameObject> existingInsDocs = new List<GameObject>();
        //check the array for docs that were thrown out
        foreach (GameObject go in allInsDocs)
        {
            if (go != null)
            {
                //if doc has not been deleted,
                //add it to existing docs array
                existingInsDocs.Add(go);
            }
        }

        //go through the array and see what docs are connected to what
        List<GameObject> InsConns = new List<GameObject>();
        for (int i = 0; i < existingInsDocs.Count; i++)
        {
            //if that doc is connected to another satanic doc, add one to the tally
            if (allInsDocs.Contains(existingInsDocs[i].GetComponent<lines>().close))
            {
                tally++;
            }

        }
        //when done, return the tally
        return tally;
    }

    int getSuicideConnections()
    {
        //return the number of suicide docs that are connected to other satanic docs
        int tally = 0;
        //get all the satanic docs and put them in an array: there are 11 satan docs
        List<GameObject> allSuicideDocs = listOfDocs.GetComponent<ListOfDocs>().suicideDocs;
        //copy that array into one of existing docs, and one to check against
        List<GameObject> existingSuicideDocs = new List<GameObject>();
        //check the array for docs that were thrown out
        foreach (GameObject go in allSuicideDocs)
        {
            if (go != null)
            {
                //if doc has not been deleted,
                //add it to existing docs array
                existingSuicideDocs.Add(go);
            }
        }

        //go through the array and see what docs are connected to what
        List<GameObject> suicideConns = new List<GameObject>();
        for (int i = 0; i < existingSuicideDocs.Count; i++)
        {
            //if that doc is connected to another satanic doc, add one to the tally
            if (allSuicideDocs.Contains(existingSuicideDocs[i].GetComponent<lines>().close))
            {
                tally++;
            }

        }
        //when done, return the tally
        return tally;
    }

    public bool getOutcome()
    {
        Debug.Log("ENtering outcome");
        //this determines which outcome occurs based on how the docs are arranged on the wall
        //this should only be called when play is over

        /*//find all the docs
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("doc");
        
        //now see what is connected to what
        //store that in another array (cons) so that:
        //gos[0] is connected to cons[0]
        List<GameObject> cons = new List<GameObject>();
        for(int i = 0; i < gos.Length; i++)
        {
            //GameObject obj = gos[i];
            //Debug.Log(gos[i].gameObject.name + "should be one");
            cons.Add(gos[i].GetComponent<lines>().close);
            Debug.Log(gos[i].gameObject.name + i);
            Debug.Log(gos.Length + "GOS");
            Debug.Log(cons.Count + "cons");
        }*/

        //This is where the calculation starts:

        //satanic docs, insurance docs, and suicide docs
        //check how many satanic docs are connected:
        int satanNum = getSatanicConnections();
        //check how many insurance docs are connected:
        int insNum = getInsConnections();
        //check how many suicide docs are connected:
        int suicideNum = getSuicideConnections();
        
        //Compare and find which outcome has the most connections:
        if(satanNum > insNum && satanNum > suicideNum)
        {
            //more satanic connections than anything else
            //play the satanic ending
            Debug.Log("Satanic END 1");
            //tell the day change script that this is the last day
            dayChanger.GetComponent<daychange>().ending = "satanic";
            done = true;
            return true;

        }
        if (insNum > satanNum && insNum > suicideNum)
        {
            //more insurance connections than anything else
            //play the insurance ending
            Debug.Log("Ins END 2");
            //tell the day change script that this is the last day
            dayChanger.GetComponent<daychange>().ending = "insurance";
            done = true;
            return true;


        }
        if (suicideNum > insNum && suicideNum > satanNum)
        {
            //more suicide connections than anything else
            //play the suicide ending
            Debug.Log("Suicide ENding 3");
            //tell the day change script that this is the last day
            dayChanger.GetComponent<daychange>().ending = "suicide";
            done = true;
            return true;

        }
        else
        {
            //there is an equal amount of connections between the highest two outcomes
            //play one of those endings, always pick away from suicide
            if(satanNum == suicideNum)
            {
                //if # satan connections = # suicide connections
                //play the satan ending
                Debug.Log("Satanic END 4");
                //tell the day change script that this is the last day
                dayChanger.GetComponent<daychange>().ending = "satanic";
                done = true;
                return true;
            }
            if(satanNum == insNum)
            {
                //if # satan connections = # insurance connections
                //play the insurance ending
                Debug.Log("Ins END 5");
                //tell the day change script that this is the last day
                dayChanger.GetComponent<daychange>().ending = "insurance";
                done = true;
                return true;
            }
            if (insNum == suicideNum)
            {
                //if # insurance connections = # suicide connections
                //play the insurance ending
                Debug.Log("Ins END 6");
                //tell the day change script that this is the last day
                dayChanger.GetComponent<daychange>().ending = "insurance";
                done = true;
                return true;

            }
            else
            {
                //if you somehow get here,
                //play the satanic ending because you are a motherfucker
                Debug.Log("Satanic END 7");
                //tell the day change script that this is the last day
                dayChanger.GetComponent<daychange>().ending = "satanic";
                done = true;
                return true;
            }
        }

           /* // temporarily it is this:
            //warm colors, docs 1, 4, and 5 connected make you win
            //cool colors, docs 2 and 3, make you lose
            //if they are all connected or not clearly connected, you lose
            object[] tempCons = cons.ToArray();
        GameObject[] array = new GameObject[cons.Count];
        cons.CopyTo(array);

        //counters for warm and warm
        int warmMatches = 0;
        int coldMatches = 0;
        for (int j = 0; j < gos.Length; j++)
        {
            Debug.Log("wooop" + j);
            bool goswarm;
            bool conswarm;

            if(gos[j].gameObject.name == "floorDoc1" || (gos[j].gameObject.name == "floorDoc4" || gos[j].gameObject.name == "floorDoc5"))
            {
                //its a warm colored doc
                goswarm = true;
            }
            else
            {
                goswarm = false;
                //its a cool colored doc
            }

            //Now for other array
            if (array[j].gameObject.name == "floorDoc1" || (array[j].gameObject.name == "floorDoc4" || array[j].gameObject.name == "floorDoc5"))
            {
                //its a warm colored doc
                conswarm = true;
            }
            else
            {
                conswarm = false;
                //its a cool colored doc
            }

            //now see if they are equal
            if(goswarm && conswarm)
            {
                warmMatches++;
            }
            else
            {
                coldMatches++;
            }

        }
        //now compare the tallies
        if (coldMatches > warmMatches)
        {
            finalDisplay = "You win and leave prison. Yay";
            Debug.Log("WIN");
        }
        else
        {
            finalDisplay = "You lose and stay in prison";
            Debug.Log("Lose");
        }*/
        done = true;
        return true;
    }

    public bool allOnWall(int totalDocs)
    {
        //Call this every time a a doc is placed on the wall
        //get all docs that are instantiated
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("doc");

        if (gos.Length < totalDocs)
        {
            //if the number of docs existing in the world is less than 
            //the total docs that will be instantiated
            return false;
        }

        //if every doc is in the world, check if all docs are on the wall
        foreach (GameObject go in gos)
        {
            if (!go.GetComponent<wallDocProperties>().onWallNow)
            {
                //if you find a doc not on the wall, return false
                return false;
            }
        }
        //otherwise, all docs are in play and are on the wall
        //so ask player if they are done arranging
        checkIfDone = true;
        return true;
    }


// Use this for initialization
void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //this will be changed from PickUpDOcs
        if (checkWall)
        {
            allOnWall(numDocs);
            
        }

        //if player is prompted to be finished
        //if (checkIfDone && lastSleep)//player went to sleep on last day
        if(lastSleep && !gotOutcome)
        {
            //this needs to be changed to them just sleeping
           gotOutcome = getOutcome();
            lastSleep = false;
            //make sure getOutcome isn't called again, because if you ended up in hell you should be alone in hell
            /*//and they say Yes I'm done
            if (Input.GetKeyDown(KeyCode.Y))
            {
                checkIfDone = false;
                //determine the outcome
                getOutcome();
               
            }
            //or if they say No I'm not done
            if (Input.GetKeyDown(KeyCode.N))
            {
                //return to arranging
                //stop displaying the prompt
                checkIfDone = false;
            }*/
        }

	}

    void onGUI()
    {
        
    }
}
