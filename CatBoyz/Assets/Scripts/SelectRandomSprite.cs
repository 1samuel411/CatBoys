using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomSprite : MonoBehaviour
{ 

    public new SpriteRenderer renderer;
    public Sprite[] sprites;

    void Start()
    {
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void Update()
    {
    }
}
