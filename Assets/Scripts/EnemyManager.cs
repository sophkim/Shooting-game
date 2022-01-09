using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // �ʿ� �Ӽ�: ���� �ð�, �� ����, ����ð�
    float createTime;
    float currentTime;
    public GameObject enemyFactory;

    public float minTime = 1;
    public float maxTime = 5;

    // ���ʹ� ������Ʈ Ǯ ũ��, ������ƮǮ, SpawnPoint ���� ����
    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        // �¾ �� �� ���� �ð��� ����
        createTime = Random.Range(minTime, maxTime);

        // ������ƮǮ ����� ����
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
        // 1. ��� �ð��� �귯����
        currentTime += Time.deltaTime;
        // 2. ���� �ð��� �Ǹ�(��� �ð��� ���� �ð��� �ʰ��ϸ�)
        if (currentTime > createTime)
        {
            //������ƮǮ���� enemy�� ������ ���
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemy.SetActive(true);

                enemyObjectPool.RemoveAt(0);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }

            // ��� �ð� �ʱ�ȭ
            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);
        }
    }
}
