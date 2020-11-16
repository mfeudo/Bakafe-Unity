using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxWriter : MonoBehaviour
{
    // Field for a text writer single

    private static TextBoxWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    // Static function, means that a reference for TextWriter in TextboxManager no longer needs to be used.
    // Note: Action types are a void delegate
    public static TextBoxWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    private TextBoxWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextBoxWriterSingle textBoxWriterSingle = new TextBoxWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textBoxWriterSingleList.Add(textBoxWriterSingle);
        return textBoxWriterSingle;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textBoxWriterSingleList.Count; i++)
        {
            // If UI text matches the one we're looking for,
            // then let's remove this one.
            if (textBoxWriterSingleList[i].GetUIText() == uiText)
            {
                textBoxWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        Debug.Log(textBoxWriterSingleList.Count);
        for (int i = 0; i < textBoxWriterSingleList.Count; i++)
        {
            bool destroyInstance = textBoxWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textBoxWriterSingleList.RemoveAt(i);
                // Because we're doing this in the for loop,
                // we have to go back one to not skip one
                i--;
            }
        }
    }

    // Writing a nest class to handle multiple instances of text writers
    // in a single game object.
    // Represents a single TextWriter instance
    public class TextBoxWriterSingle
    {

        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextBoxWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }

        // Returns true on complete
        public bool Update()
        {
            //if (uiText != null) // Checks if text writer is active
            //{
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                    // Display next character
                    timer += timePerCharacter;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacters)
                    {
                        // Color tag = RRGGBBAA
                        text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text;
                if (characterIndex >= textToWrite.Length)
                {
                    // Entire string displayed
                    //uiText = null;
                    //return;
                    if (onComplete != null) onComplete();
                    // Reaching the end
                    return true;

                }
            }

            return false;
            //}
        }

        public Text GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextBoxWriter.RemoveWriter_Static(uiText);
        }

    }
}
