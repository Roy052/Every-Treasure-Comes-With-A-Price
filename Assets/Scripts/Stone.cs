using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite original, change;
    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    public void Blight()
    {
        spriteRenderer.sprite = change;
        StartCoroutine(WaitForBlight());
    }

    IEnumerator WaitForBlight()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = original;
    }

    private void OnDestroy()
    {
        StopCoroutine(WaitForBlight());
    }
}
