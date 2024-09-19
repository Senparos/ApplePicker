using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //prefab for instantiating apples
    public GameObject applePrefab;

    //prefab for instantiating branches
    public GameObject branchPrefab;

    //speed at which ghe AppleTree moves
    private float speed = 10f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.02f;

    //delay value
    private float appleDropDelay = 2f;

    //branch chance: this value is used to determine the chance that this occurs
    public int branchDropChance = 4;

    //variable to grab the score
    public ScoreCounter scoreCounter;

    //variable to store the temp random number
    private int rand = 0;

    // Start is called before the first frame update
    void Start()
    {
        //reset vals for round 1
        speed = 10f;
        appleDropDelay = 2f;

        //find a gameobject named scorecounter in the scene hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();   

        //start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple(){
        rand = UnityEngine.Random.Range(0, branchDropChance);
        if(rand == 0){
            GameObject branch = Instantiate<GameObject>(branchPrefab);
            branch.transform.position = transform.position;
            Invoke(nameof(DropApple), appleDropDelay);
        }
        else{
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke(nameof(DropApple), appleDropDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updating round info
        if(scoreCounter.score == 500){
            speed = 12.5f;
            appleDropDelay = 1.75f;
        }
        else if(scoreCounter.score == 1000){
            speed = 15f;
            appleDropDelay = 1.5f;
        }
        else if(scoreCounter.score == 2000){
            speed = 17.5f;
            appleDropDelay = 1f;
        }

        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        //chnaging direction
        if(pos.x < -leftAndRightEdge){
            pos.x = -leftAndRightEdge;//checking left boundary
            speed = Mathf.Abs(speed);//move right
        }
        else if(pos.x > leftAndRightEdge){
            pos.x = leftAndRightEdge;//chcecking right boundary
            speed = -Mathf.Abs(speed);//move left
        }
        transform.position = pos;
    }
    void FixedUpdate(){
        if(UnityEngine.Random.value < changeDirChance)
            speed *= -1;//change direction
    }
}
