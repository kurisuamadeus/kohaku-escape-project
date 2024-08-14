using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    void OnTriggerEnter(Collider coll){
        //Check whether player has key or not
        if(coll.gameObject.GetComponent<Player>() != null){
            Debug.Log("PlayerEnterGoal");
            Player player = coll.gameObject.GetComponent<Player>();
            if(coll.gameObject.GetComponent<Player>().hasKey){
                //Trigger Win Screen when player has key while standing on goal
                player.winLoseHandler.DisplayWinScreen();
            }else{
                //gave notification to player that "key" is required
                player.winLoseHandler.ToggleNoKeyNotification();
            }
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.GetComponent<Player>() != null){
            //hide the notification about key requirement
            Player player = coll.gameObject.GetComponent<Player>();
            player.winLoseHandler.ToggleNoKeyNotification();
        }
    }
}
