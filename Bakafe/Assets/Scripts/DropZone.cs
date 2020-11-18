using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    // Start is called before the first frame update
    public CraftingManager CraftingManager;
    public void OnPointerEnter(PointerEventData eventData){

    }
     public void OnPointerExit(PointerEventData eventData){
        
    }
     public void OnDrop(PointerEventData eventData){
        CraftingManager = GameObject.FindObjectOfType<CraftingManager>();
        string tempObjectName = eventData.pointerDrag.name;
        CraftingManager.AddIngredient(tempObjectName, gameObject.name);
         
         Debug.Log (eventData.pointerDrag.name + "drop to" + gameObject.name);
        
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
       if(d!=null){
            d.parentToReturnTo = this.transform;
      }
        Debug.Log ("drop");
    }
}
