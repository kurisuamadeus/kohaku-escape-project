using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    void OnTriggerEnter(Collider coll){

        if(coll.GetComponent<Enemy>() == true){
            //Make enemy change its destination when enter the room
            Enemy enemy = coll.GetComponent<Enemy>();
            if(enemy.enemyState == Enemy.EnemyState.Patrol){
                enemy.currRoom = gameObject;
                enemy.Patrol();
            }
        }

    }
}
