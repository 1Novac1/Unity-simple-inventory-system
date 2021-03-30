using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour, IPointerClickHandler
{
    public Action MouseRightClickFunc = null;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            if (MouseRightClickFunc != null) MouseRightClickFunc();
    }
}