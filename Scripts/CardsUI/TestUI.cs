using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TestUI : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }
}