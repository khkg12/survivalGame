using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{    
    public GameObject monster;
    float spawnSpeed = 10f;
    bool isEnd = true;
    public List<GameObject> monsterList;
    int monsterGrade = 0;
    public int StageCnt
    {
        get => stageCnt;
        set
        {
            stageCnt = value;
            if(stageCnt % 5 == 0 && monsterGrade < 2)
            {
                Debug.Log("카운트오름");
                monsterGrade++;
                monster = monsterList[monsterGrade];
            }
        }
    }
    int stageCnt;

    void Start()
    {
        monster = monsterList[monsterGrade];
        StartCoroutine(Spawn());      
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            if(spawnSpeed == 1f)
            {
                isEnd = false;
            }
            Instantiate(monster, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
            StageCnt++;
            if (isEnd)
            {
                spawnSpeed -= 0.1f;
            }            
        }        
    }

    
}
