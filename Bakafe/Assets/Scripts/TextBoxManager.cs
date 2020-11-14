using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour{

    //the textbox in game
    public GameObject textbox;
    
    //the textboxes for the choice options
    public Text choiceOneTextbox;
    public Text choiceTwoTextBox;


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

//buttons for choices

    public Button choiceOneButton;
    public Button choiceTwoButton;
    
//flag for if a choice is being made, an int so we can track and pull from muiltiple choices

    public int choice;
    // Start is called before the first frame update
    void Start()
    {

    Button btnContinue = continueButton.GetComponent<Button>();
	btnContinue.onClick.AddListener(ContinueButtonClick);

    Button btnOptionOne = choiceOneButton.GetComponent<Button>();
	btnOptionOne.onClick.AddListener(OptionOneButtonClick);

    Button btnOptionTwo = choiceTwoButton.GetComponent<Button>();
	btnOptionTwo.onClick.AddListener(OptionTwoButtonClick);

    //sort all of the text into the text file array separating by new line characters, there is probably a better/smarter way to do this that we can think of 
        if (textFile != null){
            textLines = (textFile.text.Split('\n'));
        }
        

        //if(endAtLine == 0){
            //endAtLine = textLines.Length - 1;
        //}

        currentLine=1;
        endAtLine =24;

        choiceOneTextbox.text = "";
        choiceTwoTextBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Return)&&(currentLine<endAtLine)){
            currentLine++;
        }

        //check for the first decision
        if(currentLine == 24){
            choice = 1;
        }

        if(choice==1){
            continueButton.gameObject.SetActive(false);
            choiceOneTextbox.text = textLines[25];
            choiceTwoTextBox.text = textLines[26];
            choiceOneButton.gameObject.SetActive(true);
            choiceTwoButton.gameObject.SetActive(true);

        }
        //triggers if a choice is not currently happening
        if(choice ==0){
            choiceOneButton.gameObject.SetActive(false);
            choiceTwoButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
           
        }

    }

    void ContinueButtonClick(){
        if(currentLine<endAtLine){
            currentLine++;
        }
        
    }

    void OptionOneButtonClick(){
        if(choice == 1 ){
            currentLine = 27;
            endAtLine = 28;
        }

        //reset all of the UI
        choice = 0;
        choiceOneTextbox.text = "";
        choiceTwoTextBox.text = "";
    }

    void OptionTwoButtonClick(){
        if(choice==1){
            currentLine = 29;
            endAtLine = 30;
        }

         //reset all of the UI
        choice = 0;
        choiceOneTextbox.text = "";
        choiceTwoTextBox.text = "";
            
    }
}
