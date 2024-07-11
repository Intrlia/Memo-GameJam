using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//, IPointerEnterHandler, IPointerExitHandler
public class OnButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private bool isHovering = false;

    void Start() {
    }

    void Update() {
        
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;
        //Debug.Log("OnPointerEnter()---" + isHovering);
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;
        //Debug.Log("OnPointerExit()---" + isHovering);
    }

    public bool GetIsHovering() {
        //Debug.Log("GetIsHovering()---" + isHovering);
        return isHovering;
    }

}
