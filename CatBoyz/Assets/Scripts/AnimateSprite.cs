using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSprite : MonoBehaviour
{

    public new SpriteRenderer renderer;
    public Sprite[] sprites;
    public int index;
    public float speed = 0.1f;

    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if(timer >= speed)
        {
            index++;
            if (index >= sprites.Length)
                index = 0;
            timer = 0;
        }

        timer += Time.deltaTime;
        renderer.sprite = sprites[index];
    }
}
