using UnityEngine;
using System.Collections;

public class freezeRot : MonoBehaviour {
   public bool isStuck = false;
   public bool moveOver = false;

    bool localOnWall = false;
    public GameObject c;

    void OnCollisionEnter(Collision col)
    {
        
        if (col.collider.gameObject.name == "StickyWall")
        {
           
            //rotate plane to be flush with wall
            //stick it to the wall
            if (!isStuck)// && !GameObject.Find("Player").GetComponent<DragRigidbodies>().movingAStuckNote)
            {
                isStuck = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
          
        }
    }

    void OnCollisionExit(Collision col)
    {
        isStuck = false;
    }

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }
}
