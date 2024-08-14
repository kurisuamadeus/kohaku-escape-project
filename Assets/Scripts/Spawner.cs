using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Room[] rooms;
    public GameObject enemyObj;
    public GameObject chestObj;
    private int chestCount = 6;
    private int enemyCount = 6;
    public List<int> enemySpawnPoint;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> chests = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //Spawning chest process
        for(int i = 0; i < rooms.Length; i++){
            
            int randTemp = Random.Range(1, 10);
            if(rooms.Length - i+1 > chestCount){
                if(randTemp <= 4 && chestCount > 0){
                    chests.Add(
                        Instantiate(
                        chestObj, 
                        new Vector3(rooms[i].gameObject.transform.position.x, 1, rooms[i].gameObject.transform.position.z), 
                        rooms[i].gameObject.transform.rotation)
                    );
                    chestCount--;
                }else{
                    enemySpawnPoint.Add(i);
                }
            }else{
                chests.Add(
                        Instantiate(
                        chestObj, 
                        new Vector3(rooms[i].gameObject.transform.position.x, 1, rooms[i].gameObject.transform.position.z), 
                        rooms[i].gameObject.transform.rotation)
                );
            }
        }
        chests[Random.Range(0, chests.Count-1)].GetComponent<Chest>().hasKey = true;
        //Start enemy spawn process
        StartCoroutine(EnemySpawnTimer());
    }

    IEnumerator EnemySpawnTimer(){
        for (int i = 0; i < enemyCount; i++)
        {
            yield return new WaitForSeconds(5 * (i+1));
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        
        int randTemp = Random.Range(0, enemySpawnPoint.Count-1);
        Vector3 spawnPos = new Vector3(
            rooms[enemySpawnPoint[randTemp]].gameObject.transform.position.x, 
            1, 
            rooms[enemySpawnPoint[randTemp]].gameObject.transform.position.z);
        enemies.Add(Instantiate(enemyObj, spawnPos, rooms[enemySpawnPoint[randTemp]].gameObject.transform.rotation));
        enemies[enemies.Count-1].GetComponent<Enemy>().spawner = GetComponent<Spawner>();
    }
}
