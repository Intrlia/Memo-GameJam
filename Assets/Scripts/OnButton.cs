using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//, IPointerEnterHandler, IPointerExitHandler
public class OnButton : MonoBehaviour {
    private bool isHovering = true;

    void Update() {
        if (IsMouseOverButton()) {
            if (!isHovering) {
                isHovering = true;
            }
        } else {
            if (isHovering) {
                isHovering = false;
            }
        }
    }

    private bool IsMouseOverButton() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return true;
        }
        return false;
    }

    //public void OnPointerEnter(PointerEventData eventData) {
    //    isHovering = true;
    //    Debug.Log("Mouse hovering over the object.---" + isHovering);
    //}

    //public void OnPointerExit(PointerEventData eventData) {
    //    isHovering = false;
    //    Debug.Log("Mouse no longer hovering over the object.---" + isHovering);
    //}

    public bool GetIsHovering() {
        //Debug.Log("GetIsHovering()---" + isHovering);
        return isHovering;
    }
}
