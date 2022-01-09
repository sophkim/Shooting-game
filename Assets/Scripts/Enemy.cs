using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //필요 속성 : 속도
    public float speed = 5; 
    Vector3 dir;
    public GameObject explosionFactory;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        // 활성화 되었을 때 호출
        // 태어날 때 30%의 방향은 플레이어 쪽으로, 나머지는 아래로
        int randValue = Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }

        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //아래로 계속 이동
        transform.position += dir * speed * Time.deltaTime;
    }

    //다른 충돌체와 부딪히면 충돌체와 본인 둘 다 죽음
    private void OnCollisionEnter(Collision other)
    {
        // ScoreManager 점수 올려줘
        ScoreManager.Instance.Score++;

        transform.forward = Vector3.zero;

        //폭팔 효과 만들고 배치
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //부딪힌 물체가 총알이면 비활성화 시켜 탄창에 넣음, 아니라면 죽임
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 비활성화 시키고
            other.gameObject.SetActive(false);
            // 탄창에 넣음
            PlayerFire.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        //나 죽고
        gameObject.SetActive(false);
        EnemyManager.enemyObjectPool.Add(other.gameObject);
    }
}
