using UnityEngine;
using System.Collections;

public class PickUpDoc : MonoBehaviour {
    //This script handles:
    //picking up a document off the floor
    //snapping it to the drag mark if clicked on
    //adhering it to the wall if clicked again, should the player be facing the wall

    private Transform cam;
    private Transform dragMark;
    public GameObject currentDoc;
    public GameObject wallDoc;
    public GameObject outcomes;
    Vector3 wallDocRotation;
    float wallDocZ;
    public AudioSource paperCrumple;
    public AudioSource toilet;
    public Font myFont;

    Transform wakeUpRot;

    bool fadeIn = false;
    bool fadeOut = false;

    public SpriteRenderer fader;
    public GameObject preview;
    public GameObject dayChanger;

    public float fadeSpeed = .02f;          // Speed that the screen fades to and from black.
    public GUITexture fade = new GUITexture();

    public string sub;
    public bool displaySub = false;

    bool holding = false;
    bool displayFullDoc = false;
    bool canFlush = false;
    public bool dayDone;
    public bool canSleep = false;

    int distToPlayer = 7;

    public SpriteRenderer sprite;

    void handleMouseClick()
    {
        Debug.Log("CLicked!");
        //if the player is not holding a paper
        if (!holding)
        {
            //Shoot a ray to see what player's clicking on
            if (dragMark == null || cam == null)
                return;
            //shoot a ray to see if it hits something
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            //if it hits, check if it's a document
            if (Physics.Raycast(ray, out hit, distToPlayer) && hit.collider.gameObject.tag == "doc")
            {
                //if this is a new doc, not yet on the wall
                if (!(hit.collider.gameObject.GetComponent<wallDocProperties>().beenPlaced))
                {
                    //player is now holding a paper
                    holding = true;
                    //Display the full image
                    displayFullDoc = true;
                    //the player is holding THIS specific paper
                    currentDoc = hit.collider.gameObject;
                    //make the current doc invisible
                    currentDoc.GetComponent<SpriteRenderer>().enabled = false;
                    //snap the appropriate sprite to the drag mark location (in onGUI)
                    //set the correct sprite to the dragmark spriterender
                    Debug.Log("Clicked a doc");
                    //make the sprite visible (inOnGui)
                    // play the exmaining a paper sound
                    paperCrumple.Play();
                    return;
                }
                // play the exmaining a paper sound
                paperCrumple.Play();
                //if this doc was on the wall
                //player is now holding a paper
                holding = true;
                //Display the full image
                displayFullDoc = true;
                //the player is holding THIS specific paper
                currentDoc = hit.collider.gameObject;
                //but don't move the doc unless they click somewhere else!

            }
            //stop outcomes script running
            outcomes.GetComponent<outcomes>().checkWall = false;
            //keep holding the paper
            return;
        }

        //If the player is holding a paper
        if (holding)
        {
            //The player is holding a paper and they have clicked.
            //The full image should be displaying
            //Shoot a ray to see if player is facing the sticky wall
            if (dragMark == null || cam == null)
                return;
            //shoot a ray to see if it hits something
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            //if it hits, check if it's the stickywall
            if (Physics.Raycast(ray, out hit, 8) && hit.collider.gameObject.name == "StickyWall")
            {
                //player is no longer holding the paper
                holding = false;
                //snap sprite to that location on the wall by moving the current doc, which is invisible
                //Make its rotation/position flush to the stickywall
                currentDoc.transform.rotation = wallDoc.transform.rotation;
                currentDoc.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                //Make sprite visible on the wall
                currentDoc.GetComponent<SpriteRenderer>().enabled = true;
                //tell the doc that it has been on the wall
                currentDoc.GetComponent<wallDocProperties>().beenPlaced = true;
                //tell the doc its currently on the wall
                currentDoc.GetComponent<wallDocProperties>().onWallNow = true;
                //make the sprite invisible on the dragmark (in onGUI)
                //make full image invisible
                displayFullDoc = false;
             

            }
            //if player is holding a doc and is hovering over the toilet,
            if (Physics.Raycast(ray, out hit, 8) && hit.collider.gameObject.name == "toilet")
            {
                //Show the preview of the doc, indicating you can flush the doc
            }
                //now check if all docs are on the wall
                outcomes.GetComponent<outcomes>().checkWall = true;
            //keep not holding the paper
            return;

        }
        }

	// Use this for initialization
	void Start () {
        //Tyler's dragmark handling
        if (GameObject.Find("DragMark"))
            dragMark = GameObject.Find("DragMark").transform;
        else
            Debug.LogError("No DragMark found. Make sure there's an empty GameObject called DragMark that's attached to the Main Camera");

        if (Camera.main != null)
            cam = Camera.main.transform;
        else
            Debug.LogError("No Main Camera found. Make sure there's a camera tagged as MainCamera");

        wallDocRotation = new Vector3(3.932449f, 38.16376f, 5.709717f);
        wallDocZ = -2.23f;
        wallDoc.GetComponent<SpriteRenderer>().enabled = false;

        sub = "Press Space to Examine";

        fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, 0);
        preview.GetComponent<SpriteRenderer>().enabled = false;

        //grab initial rotation
        wakeUpRot = gameObject.transform;


    }

    void FadeToClear()
    {
        if (fader.color.a > 0f)
        {
            // Lerp the colour of the texture between itself and black.
            float a = fader.color.a - .007f;
            
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, a);
            // fade.color = Color.Lerp(fade.color, Color.black, fadeSpeed * Time.deltaTime);
        }
        else
        {
            fadeIn = false;
        }
    }


    void FadeToBlack()
    {
        if (fader.color.a < 1f)
        {
            // Lerp the colour of the texture between itself and black.
            float a = fader.color.a + .007f;
            
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, a);
            // fade.color = Color.Lerp(fade.color, Color.black, fadeSpeed * Time.deltaTime);
        }
        else
        {
            //screen is black
            fadeOut = false;
            //turn player position
            gameObject.transform.position = new Vector3(-17.97f, 3.47f, -3.63f);
           
            //start the fade in
            fadeIn = true;
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            //going to sleep
            FadeToBlack();
        }

            if (fadeIn)
            {
                //waking up
                FadeToClear();
            }

            //check if mouse was clicked
            if (Input.GetMouseButtonDown(0))
            {
                handleMouseClick();
            }


            //checking if looking at the toilet
            if (holding)
            {
                //If I'm not holding a document and I'm not examining a document
                //Shoot a ray to see what player's hovering on
                if (dragMark == null || cam == null)
                    return;
                //shoot a ray to see if it hits something
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                //if it hits, check if its the toilet
                if (Physics.Raycast(ray, out hit, distToPlayer) && hit.collider.gameObject.tag == "toilet")
                {
                Debug.Log("Looking at the toilet");
                    //if its the toilet, check if you are holding a doc:
                    if (holding)
                    {
                        //if you are holding a doc, show option to flush doc
                        canFlush = true;
                    Debug.Log("I should get ALLLL the way here");
                    }
                }
            else
            {
                //if its not the toilet anymore, don't display or let them flush!
                canFlush = false;
            }
            }

            //checking if looking at the bed
            if (!holding && !displayFullDoc)
            {
                //If I'm not holding a document and I'm not examining a document
                //Shoot a ray to see what player's hovering on
                if (dragMark == null || cam == null)
                    return;
                //shoot a ray to see if it hits something
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                //if it hits, check if its the bed
                if (Physics.Raycast(ray, out hit, distToPlayer) && hit.collider.gameObject.tag == "bed")
                {
                    //if its the bed, check if dayisDone, if so we can sleep
                    Debug.Log("LOOKING AT THE BED");
                    if (dayDone)
                    {
                        canSleep = true;
                    if (dayChanger.GetComponent<daychange>().day8)
                    {
                        //if the player has slept on the final day, give them an ending
                        outcomes.GetComponent<outcomes>().lastSleep = true;
                    }
                    }
                }
            else
            {
                //if its not the bed anymore, don't display or let them sleep!
                canSleep = false;
            }
        }
            //check if mouse is hovering over a document
            if (!holding && !displayFullDoc)
            {
                //If I'm not holding a document and I'm not examining a document
                //Shoot a ray to see what player's hovering on
                if (dragMark == null || cam == null)
                    return;
                //shoot a ray to see if it hits something
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                //if it hits, check if it's a document
                if (Physics.Raycast(ray, out hit, distToPlayer) && hit.collider.gameObject.tag == "doc")
                {
                    //If its a doc, display subtitle
                    displaySub = true;
                    sub = hit.collider.gameObject.GetComponent<wallDocProperties>().subtitle;
                /*//if its been read, show its unique subtitle
                sub = hit.collider.gameObject.GetComponent<wallDocProperties>().subtitle;
                if (currentDoc.gameObject.GetComponent<wallDocProperties>().read)
                {
                    sub = hit.collider.gameObject.GetComponent<wallDocProperties>().subtitle;
                }
                else
                {
                    //displays its temp subtitle
                    sub = hit.collider.gameObject.GetComponent<wallDocProperties>().tempSub;
                }*/
                //the player is hovering over THIS specific paper
                currentDoc = hit.collider.gameObject;
                   /* //If player presses space, blow texture in window
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //play the exmaining a paper sound
                        paperCrumple.Play();
                        //blow up texture
                        displayFullDoc = true;
                        Debug.Log("should display");
                        //set this document's read value to true
                        hit.collider.gameObject.GetComponent<wallDocProperties>().read = true;
                    }*/
                }
                else
                {
                    //if its not a doc, or nothing, display nothing
                    displaySub = false;
                    canFlush = false;
                    //If player presses space, blow texture in window
                    /*if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //blow up texture
                        displayFullDoc = true;
                        Debug.Log("should display");
                        //set this document's read value to true
                        hit.collider.gameObject.GetComponent<wallDocProperties>().read = true;
                    }*/
                }
                return;
            }

           /* if (displayFullDoc && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("I should have shut down");
                //if showing the full text and player presses space, return to normal view
                displayFullDoc = false;
            }*/
        }
    

   
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.font = myFont;
        myStyle.alignment = TextAnchor.UpperCenter;

       
        //the crosshair
      // GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        

        //if hovering over the bed and all docs placed or destroyed
        if (!holding && canSleep)
        {
            //Show an option to sleep
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2.2f, 100, 100), "Sleep", myStyle);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("THEY Slept");
                GameObject.Find("DayController").GetComponent<daychange>().timeTochange = true;
                displayFullDoc = false;
                canFlush = false;
                canSleep = false;
                dayDone = false;
                holding = false;
                //fade the screen to black
                fadeOut = true;
            }
        }

        //if hovering over the toilet and holding a doc
        if (holding && canFlush)
        {
            Debug.Log("CAN FLUSH");
            //Show an option to flush
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2.2f, 100, 100), "Flush", myStyle);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("THEY FLUSHED IT");
                //play the flush sound
                toilet.Play();
                displayFullDoc = false;
                Destroy(currentDoc);
                canFlush = false;
                holding = false;
            }
        }

        if (displayFullDoc)
        {
            //if we are showing the full doc to the player
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), currentDoc.GetComponent<wallDocProperties>().fullImage);

            if (!canFlush && !canSleep)
            {
                //Show cursor
                GUI.Label(new Rect(0, Screen.height / 2f, Screen.width, 100), "X", myStyle);
            }
            //show nothing else
            return;
        }

        
        if (holding)
        {
            //if player is holding a document, snap the doc sprite to the crosshair
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2.2f, 100, 100), currentDoc.GetComponent<wallDocProperties>().icon);
        }

        if (!holding && displaySub)
        {
            //Display subtitle if not holding anything and pointing at a doc
            // GUI.Label(new Rect((Screen.width / 2f), (Screen.height / 2f), 200, 200), sub, myStyle);
            GUI.Label(new Rect(0, (Screen.height / 1.7f), Screen.width, 200), sub, myStyle);
            GUI.Label(new Rect(0, Screen.height / 2f, Screen.width, 100), "X", myStyle);
        }

        if(outcomes.GetComponent<outcomes>().checkIfDone)
        {
            //Prompt player if they are done arranging
           // GUI.Label(new Rect((Screen.width / 2f) - 1f, (Screen.height / 2.2f) - 1f, 200, 200), "Are you done? Y or N");
        }

        if (outcomes.GetComponent<outcomes>().done)
        {
            GUI.Label(new Rect((Screen.width / 2f) - 1f, (Screen.height / 2.2f) - 1f, 200, 200), outcomes.GetComponent<outcomes>().finalDisplay);
        }
    
    }
    }
