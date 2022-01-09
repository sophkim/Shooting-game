using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 필요 속성 : 스크롤 속도, material
    public float scrollSpeed = 0.2f;
    public Material bgMaterial;

    void Start()
    {
        
    }
    void Update()
    {
        // 배경 스크롤(이동 : P = P0 + vt)
        Vector2 direction = Vector2.up;
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;


    }
}
