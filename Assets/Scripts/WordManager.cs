using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public GameObject myParticleSystem;

    public GameObject level1Effect1;
    public GameObject level1Effect2;
    public GameObject level1Effect3;
    public GameObject level1Effect4;

    public GameObject level2Effect1;
    public GameObject level2Effect2;
    public GameObject level2Effect3;

    public GameObject level3Effect1;


    public Text streakScore;
    public int streakScoreValue;

    //public WordDisplay wordDisplay;
    private bool hasActiveWord;
    private Word activeWord;


    private void Start()
    {
        AddWord();
        //AddWord();
        //AddWord();
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log("New letter is : " + word.word);
        words.Add(word);
    }

    public int getStreakCount()
    {
        return streakScoreValue;
    }

    public void TypeLetter(char letter)
    {
        //if ()
        if (hasActiveWord)
        {
            //Check if letter was next
            // Remove it from word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
            else
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter().ToString().ToLower() == letter.ToString())
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    streakScoreValue++;
                    //break;
                }
                else
                {
                    streakScoreValue = 0;
                    //words.Remove(activeWord);
                    //hasActiveWord = true;
                }
            }
            AddWord();
            words.RemoveAt(0);
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
       
    public void triggerParticleEffect(bool isSystemRunning, GameObject gameObject, int scoreRequirement)
    {
        if (isSystemRunning && streakScoreValue >= scoreRequirement)
        {
            //Debug.Log("Already playing particle effect");
        }
        else if (isSystemRunning && streakScoreValue < scoreRequirement)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
            isParticleSystemRunning = false;
        }
        else if (!isSystemRunning && streakScoreValue >= scoreRequirement)
        {
            myParticleSystem.GetComponent<ParticleSystem>().Play();
            isParticleSystemRunning = true;
        }
    }

    private bool isParticleSystemRunning = false;

    public void getLevelOne()
    {
        if (streakScoreValue >=5)
        {
            level1Effect1.SetActive(true);
            level1Effect2.SetActive(true);
            level1Effect3.SetActive(true);
            level1Effect4.SetActive(true);
        }
        else
        {
            level1Effect1.SetActive(false);
            level1Effect2.SetActive(false);
            level1Effect3.SetActive(false);
            level1Effect4.SetActive(false);
        }
    }

    public void getleveltwo()
    {
        if (streakScoreValue >= 15)
        {
            level2Effect1.SetActive(true);
            level2Effect2.SetActive(true);
            level2Effect3.SetActive(true);
        }
        else
        {
            level2Effect1.SetActive(false);
            level2Effect2.SetActive(false);
            level2Effect3.SetActive(false);
        }
    }

    public void getlevelthree()
    {
        if (streakScoreValue >=20)
        {
            level3Effect1.SetActive(true);
        }
        else
        {
            level3Effect1.SetActive(false);
        }
    }

    private void Update()
    {
        streakScore.text = streakScoreValue.ToString();
        triggerParticleEffect(isParticleSystemRunning, myParticleSystem, 10);
        getLevelOne();
        getleveltwo();
        getlevelthree();
    }

}

