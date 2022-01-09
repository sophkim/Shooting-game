using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ʿ� �Ӽ� : �ӵ�
    public float speed = 5; 
    Vector3 dir;
    public GameObject explosionFactory;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        // Ȱ��ȭ �Ǿ��� �� ȣ��
        // �¾ �� 30%�� ������ �÷��̾� ������, �������� �Ʒ���
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
        //�Ʒ��� ��� �̵�
        transform.position += dir * speed * Time.deltaTime;
    }

    //�ٸ� �浹ü�� �ε����� �浹ü�� ���� �� �� ����
    private void OnCollisionEnter(Collision other)
    {
        // ScoreManager ���� �÷���
        ScoreManager.Instance.Score++;

        transform.forward = Vector3.zero;

        //���� ȿ�� ����� ��ġ
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //�ε��� ��ü�� �Ѿ��̸� ��Ȱ��ȭ ���� źâ�� ����, �ƴ϶�� ����
        if (other.gameObject.name.Contains("Bullet"))
        {
            // ��Ȱ��ȭ ��Ű��
            other.gameObject.SetActive(false);
            // źâ�� ����
            PlayerFire.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        //�� �װ�
        gameObject.SetActive(false);
        EnemyManager.enemyObjectPool.Add(other.gameObject);
    }
}
