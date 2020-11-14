using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour{

    //the textbox in game
    public GameObject textbox;
    
    public Text theText;

    public TextAsset textFile; 

 //an array that will hold all of the dialogue   
    public string [] textLines; 

//indicates the line number that is currently being displayed on screen
    public int currentLine; 

//indicates the line number that the text should stop at, for either a choice or end of dialogue
    public int endAtLine; 

//button to advance text
    public Button continueButton;
    
    // Start is called before the first frame update
    void Start()
    {

    Button btn = continueButton.GetComponent<Button>();
		btn.onClick.AddListener(ContinueButtonClick);

    //sort all of the text into the text file array separating by new line characters, there is probably a better/smarter way to do this that we can think of 
        if (textFile != null){
            textLines = (textFile.text.Split('\n'));
        }
        

        if(endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Return)&&(currentLine<endAtLine)){
            currentLine++;
        }

    }

    void ContinueButtonClick(){
        if(currentLine<endAtLine){
            currentLine++;
        }
        
    }
}
