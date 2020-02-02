using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int maxHp;
    public int curHp;

    public Image heartImage;

    void Start()
    {
        curHp = 0;   
    }

    void Update()
    {
        heartImage.fillAmount = curHp / (float)maxHp;
    }

    public void Damage(int amount)
    {
        curHp += amount;
        if(curHp >= maxHp)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            //Destroy(gameObject);
        }

        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        SpriteRenderer[] srenderers = GetComponentsInChildren<SpriteRenderer>();
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.SetColor("_Color", Color.red);
        }

        for (int i = 0; i < srenderers.Length; i++)
        {
            srenderers[i].material.SetColor("_Color", Color.red);
        }

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.SetColor("_Color", Color.white);
        }

        for (int i = 0; i < srenderers.Length; i++)
        {
            srenderers[i].material.SetColor("_Color", Color.white);
        }
    }
}
