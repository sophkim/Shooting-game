using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // �ʿ� �Ӽ� : ��ũ�� �ӵ�, material
    public float scrollSpeed = 0.2f;
    public Material bgMaterial;

    void Start()
    {
        
    }
    void Update()
    {
        // ��� ��ũ��(�̵� : P = P0 + vt)
        Vector2 direction = Vector2.up;
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;


    }
}
