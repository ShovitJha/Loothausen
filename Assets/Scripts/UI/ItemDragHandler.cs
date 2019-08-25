﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//credit https://stackoverflow.com/questions/37473802/unity3d-ui-calculation-for-position-dragging-an-item/37473953#37473953
public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    
    public Image ghost;
    private ItemSlot itemSlot;
    private RectTransform rect;
    private MouseCursor cursor;
    
    private void Awake() {
        itemSlot = GetComponent<ItemSlot>();
        cursor = GameObject.FindObjectOfType<MouseCursor>();
        ghost.raycastTarget = false;
        ghost.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        ghost.sprite = itemSlot.GetContent().icon;
        ghost.transform.position = transform.position;
        ghost.enabled = true;
        cursor.ChangeStyle(CursorStyle.Grab);
        cursor.lockStyle = true;
    }

    public void OnDrag(PointerEventData eventData) {
        ghost.transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) {
        ghost.enabled = false;
        cursor.lockStyle = false;
    }
}
