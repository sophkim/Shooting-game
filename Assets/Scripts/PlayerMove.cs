using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //�Է� �ޱ� (�¿�, a, d)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //����
        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);
        //�̵�
        //transform.Translate(dir * speed * Time.deltaTime);
        //P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

    }
}
