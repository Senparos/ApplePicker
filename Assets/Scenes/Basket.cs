using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        //find a gameobject named scorecounter in the scene hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if(scoreGO == null)
            Debug.LogError("could not find scorecounter");
        else{
            //Get the ScoreCounter (script) component of scorego
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get current screen pos of the mouse from Inpt
        Vector3 mousePos2D = Input.mousePosition;

        //the camera's z pos sets how far to push the mouse into 3d
        //if this line causes a nullreference exception, select the main camera in the
        //hierarchy and set its tag to maincamera in the inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        //convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of thi sbasket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll){
        //find out what hits the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);
            //increase score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        if(collidedWith.CompareTag("Branch")){
            Destroy(collidedWith);
            //end game
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
