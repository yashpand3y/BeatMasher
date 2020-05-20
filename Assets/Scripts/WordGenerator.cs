using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"A", "B", "C", "D", "E", "F",
                                        "G", "H", "I", "J", "K", "L",
                                        "M", "N", "O", "P","Q", "R",
                                        "S", "T", "U", "V", "w", "x",
                                        "Y", "Z" };


    public static string GetRandomWord ()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}
