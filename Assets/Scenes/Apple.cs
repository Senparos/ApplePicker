using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update(){
        if(transform.position.y < bottomY){
            Destroy(this.gameObject);

            //get a reference to the applepicker component of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //call the public AppleMissed() method of apSCript
            apScript.AppleMissed();
        }
    }
}
