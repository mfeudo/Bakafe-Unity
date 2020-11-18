using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject crafting;


   public void OnTriggerStay2D(Collider2D target){
        Debug.Log(this.name);
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
