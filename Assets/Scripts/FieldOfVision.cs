using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVision : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){

        if(coll.gameObject.tag == "Player"){
            target = coll.gameObject;
        }
    }
    void OnTriggerExit(Collider coll){

        if(coll.gameObject.tag == "Player"){
            target = null;
        }
    }
}
