using UnityEngine;
using System.Collections;

public class lines : MonoBehaviour {
    //this is for drawing lines between docs that are on the wall
    LineRenderer linerend;
    public GameObject close;


    GameObject FindClosest()
    {
        //find the closest document
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("doc");

        if (gos[0] == null)
        {
            //if I'm the only document around, return null!
            return null;
        }
        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && (go.gameObject.name != this.gameObject.name && go.gameObject.GetComponent<wallDocProperties>().onWallNow))
            {
                //dont draw a line between this doc and this doc
                //make sure that doc is on the wall
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Use this for initialization
    void Start () {
        linerend = gameObject.GetComponent<LineRenderer>();
        linerend.SetVertexCount(2);
        linerend.SetWidth(.01f, .01f);
        linerend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<wallDocProperties>().onWallNow)
        {
            //if the doc is on the wall, start using the line renderer
            linerend.enabled = true;
            //tell line renderer positions
            //start at this doc
            linerend.SetPosition(0,gameObject.transform.position);
            //draw line to next closest doc
            GameObject go = FindClosest();
            if (go != null)
            {
                close = go;
                linerend.SetPosition(1, go.transform.position);
            }
            
        }
	}
}
