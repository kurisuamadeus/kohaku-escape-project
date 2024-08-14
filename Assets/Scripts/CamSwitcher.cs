using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public Camera cam;
    public GameObject fpsCamLoc;
    public GameObject tpsCamLoc;
    public bool isTPS;

    // Update is called once per frame
    void Update()
    {
        //Switch between First Person and Third Person
        if(Input.GetKeyDown(KeyCode.R)){
            if(isTPS == false){
                cam.transform.position = tpsCamLoc.transform.position;
                isTPS = true;
            }else if(isTPS == true){
                cam.transform.position = fpsCamLoc.transform.position;
                isTPS = false;
            }
        }
    }
}
