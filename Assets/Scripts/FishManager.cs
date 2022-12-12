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