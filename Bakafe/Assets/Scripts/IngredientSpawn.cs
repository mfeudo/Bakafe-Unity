using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    Vector2 worldPosition;
    GameObject cube;
    
    public void Start() {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cube = GameObject.Find("Cube");
    }

    public void createIngredient() {
        Instantiate(cube, worldPosition, Quaternion.identity);
    }
}
