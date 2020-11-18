using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CraftingManager : MonoBehaviour
{
    //public GameObject Coffee;
    //public GameObject Milk;
    //public GameObject Sugar;
    public Button makeDrinkButton;
    public Button resetButton;
    public GameObject craftingCanvas;
    List<string> drinkList;
    List<string> latteIngredients;
    public Dictionary<string, string> currentDrinkIngredients = new Dictionary<string, string>();
    
    // Start is called before the first frame update
    void Start()
    {
        drinkList = new List<string>();
        latteIngredients = new List<string>();
        latteIngredients.Add("Milk");
        latteIngredients.Add("Coffee");
        Button makeBtn = makeDrinkButton.GetComponent<Button>();
        Button resetBtn = resetButton.GetComponent<Button>();
		makeBtn.onClick.AddListener(MakeDrink);
        resetBtn.onClick.AddListener(Reset);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void MakeDrink(){
        
        if(drinkList.Count > 0){

        
                for (int i = 0; i < latteIngredients.Count; i++){
                    if (drinkList.Contains(latteIngredients[i])){
                        Debug.Log("correct" + drinkList[i]);
                    } else{
                        Debug.Log("incorrect" + drinkList[i]);
                    }
                   
                }
                if(drinkList.Count != latteIngredients.Count){
                        Debug.Log("incorrect number of ingredients");
                }
        }
    }
    //called when the collider from the object ingredient collides with the drink pane
    public void AddIngredient(string name, string place){
     drinkList.Add(name);
    }

    public void Reset(){
        SceneManager.LoadScene("Test_CraftinScene");

    }
    
}

