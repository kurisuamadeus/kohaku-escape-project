using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool hasKey;
    
    void OnTriggerEnter(Collider coll){

        //Gave Player key when this has key
        if(coll.gameObject.GetComponent<Player>() != null){
            if(hasKey == true){
                Player player = coll.gameObject.GetComponent<Player>();
                player.hasKey = true;
                player.winLoseHandler.DisplayGotKeyNotification();
            }
            Destroy(gameObject);
        }

    }
}
