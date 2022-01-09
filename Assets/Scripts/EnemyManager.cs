using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 필요 속성: 생성 시간, 적 공장, 경과시간
    float createTime;
    float currentTime;
    public GameObject enemyFactory;

    public float minTime = 1;
    public float maxTime = 5;

    // 에너미 오브젝트 풀 크기, 오브젝트풀, SpawnPoint 담을 변수
    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        // 태어날 때 적 생성 시간을 설정
        createTime = Random.Range(minTime, maxTime);

        // 오브젝트풀 만들어 관리
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 경과 시간이 흘러간다
        currentTime += Time.deltaTime;
        // 2. 일정 시간이 되면(경과 시간이 생성 시간을 초과하면)
        if (currentTime > createTime)
        {
            //오브젝트풀에서 enemy를 가져다 사용
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemy.SetActive(true);

                enemyObjectPool.RemoveAt(0);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }

            // 경과 시간 초기화
            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);
        }
    }
}
