using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //필요 속성 : 총알공장, 총구
    //오브젝트풀로 만들어 관리(탄창)

    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> bulletObjectPool = new List<GameObject>();

    void Start()
    {
        // 태어날 때 오브젝트풀(탄창)을 만들고, 총알 넣음
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
        //사용자가 발사버튼을 누르면 총알 발사
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
