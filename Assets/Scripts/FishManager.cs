using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{

    private FishManager.FishType type;
    private CircleCollider2D col;
    private SpriteRenderer render;
    private float ScreenLeft;

    private Tweener tweener;
    public FishManager.FishType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;   
            col.radius = type.colliderRadius;
            render.sprite = type.FishSprite;
        }
    }
    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        render = GetComponent<SpriteRenderer>();
        ScreenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
    public void ResetFish()
    {
        if(tweener != null)
        {
            tweener.Kill(false);
        }
        float num = UnityEngine.Random.Range(type.minLength, type.maxLength);
        col.enabled = true;
        Vector3 position = transform.position;
        position.y = num;
        position.x = ScreenLeft;
        transform.position = position;
        float num2 = 1;
        float y = UnityEngine.Random.Range(num - num2, num + num2);
        Vector2 v = new Vector2(-position.x, y);

        float num3 = 3;
        float  delay  = UnityEngine.Random.Range(0,2*num3);
        tweener = transform.DOMove(v, num3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
        {
            Vector3 localscale = transform.localScale;
            localscale.x = -localscale.x;
            transform.localScale = localscale;
        });
    }
    public void Hook()
    {
        col.enabled = false;
        tweener.Kill(false);
    }
    [Serializable]
public class FishType
{
        private int price;
        public float fishcount;
        public float minLength;
        public float maxLength;
        public float colliderRadius;
        public Sprite FishSprite;
}

}