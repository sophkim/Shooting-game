using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //�ʿ� �Ӽ� : �Ѿ˰���, �ѱ�
    //������ƮǮ�� ����� ����(źâ)

    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> bulletObjectPool = new List<GameObject>();

    void Start()
    {
        // �¾ �� ������ƮǮ(źâ)�� �����, �Ѿ� ����
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //����ڰ� �߻��ư�� ������ �Ѿ� �߻�
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bulletObjectPool.RemoveAt(0);
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
    }
}
