using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Word
{
    public string word;

    private int typeIndex;

    WordDisplay display;


    public Word(string inputword, WordDisplay inputdisplay)
    {
        word = inputword;
        typeIndex = 0;
        display = inputdisplay;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void  TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            display.RemoveWord();
        }

        //Destroy(gameObject, 7f);
        return wordTyped;
    }

}
