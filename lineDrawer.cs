using UnityEngine;
using System.Collections;

public class lineDrawer : MonoBehaviour {
    //PUT THIS ON THE line children
    
    LineRenderer linerender;

    public Transform origin;
    public Transform destination;

    GameObject FindClosest()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("paper");

        if (gos[0] == null) {
            //if I'm the only document around, return null!
            return null;
        }

        //System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(gos);
       /* ArrayList itemsToAdd = new ArrayList();
        ArrayList gobjs = new ArrayList();
        //check if these documents are on the wall! If they aren't, don't consider them in the search!
        foreach (GameObject g in gos)
        {
            if (g.GetComponent<freezeRot>().isStuck == true){
                itemsToAdd.Add(g);
            }
        }

        foreach(GameObject gob in itemsToAdd)
        {
            gobjs.Add(gob);
        }
     
        */
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)//gobjs)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && (go.gameObject.name != this.gameObject.name && go.gameObject.GetComponent<freezeRot>().isStuck) )
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

// Use this for initialization
void Start()
    {
        linerender = GetComponent<LineRenderer>();
        linerender.SetVertexCount(2);
        linerender.SetWidth(.2f, .2f);

        origin = this.gameObject.transform;
    }

    void Update()
    {
        GameObject cgo;
        if (GetComponentInParent<freezeRot>().isStuck)
        {
            //I am on the wall
            //Find the closest document by a spatial threshold
            cgo = FindClosest();
            
            //draw line between me and that thing
            
                linerender.SetPosition(0, origin.transform.position);
                linerender.SetPosition(1, cgo.gameObject.transform.position);
                /*linerender.SetPosition(0, origin.transform.TransformPoint(origin.transform.position));
                linerender.SetPosition(1, cgo.gameObject.transform.TransformPoint(cgo.gameObject.transform.position));
                Debug.Log("origin is" + origin.transform.TransformPoint(origin.transform.position));//cgo.gameObject.transform.TransformPoint(cgo.gameObject.transform.position));*/
            
        }
       
    }
}
