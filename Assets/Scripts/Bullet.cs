using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    
    void Start()
    {
        
    }

    void Update()
    {
        //���� ��� �̵� P = P0 + vt
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
