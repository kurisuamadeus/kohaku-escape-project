using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    public NavMeshAgent navMeshAgent;
    public GameObject currRoom;
    public Vector3 destination;
    public Spawner spawner;
    public FieldOfVision fieldOfVision;
    public enum EnemyState{
        Patrol,
        Chase
    }

    public EnemyState enemyState;
    
    // Start is called before the first frame update
    void Start()
    {
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.speed = speed * speedMultiplier;
        UpdateState();
        //Trigger Chase every frame when this on "Chase" state
        if(enemyState == EnemyState.Chase){
            Chase();
        }
    }

    void OnCollisionEnter(Collision coll){
        //Trigger Lose Screen when this hit player
        if(coll.gameObject.GetComponent<Player>() != null){
            coll.gameObject.GetComponent<Player>().winLoseHandler.DisplayLoseScreen();
        }
    }

    void UpdateState(){

        //Check if player is on sight
        if(fieldOfVision.target != null && enemyState == EnemyState.Patrol){
            enemyState = EnemyState.Chase;
            Chase();
        }else if(fieldOfVision.target == null && enemyState == EnemyState.Chase){
            enemyState = EnemyState.Patrol;
            Patrol();
        }
    }

    public void Patrol(){
        GameObject objTarget;
        //Randomize the navmesh destination for patrol behaviour
        do
        {
            int tempRand = Random.Range(0, spawner.rooms.Length-1);
            objTarget = spawner.rooms[tempRand].gameObject;
        } while (objTarget == currRoom);
        destination = new Vector3(objTarget.transform.position.x, 1, objTarget.transform.position.z);
        navMeshAgent.SetDestination(destination);
    }

    public void Chase(){
        navMeshAgent.ResetPath();
        navMeshAgent.SetDestination(fieldOfVision.target.transform.position);
    }
}
