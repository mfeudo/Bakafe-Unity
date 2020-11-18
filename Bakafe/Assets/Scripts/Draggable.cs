using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
  
{
  public Transform originalParent = null;  
  public Transform parentToReturnTo = null;
  public Transform originalPosition = null;
  public float xpos;
  public float ypos;

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log ("Begin Drag");
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
       

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log (" Drag");
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData){
        
        Debug.Log ("end Drag");
        this.transform.SetParent(parentToReturnTo);
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //EventSystem.current.RaycastAll(eventData);
    }
    
   
}
