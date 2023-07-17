using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("Canvas")] 
    public int scoreToWin;
    //public int apple;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text appleText;

    [Header("Game")] 
    public PieManager _pieManager;
    [SerializeField] private int rangeMin;
    [SerializeField] private int rangeMax;


    private void Start()
    {
        scoreToWin = Random.Range(rangeMin, rangeMax);
    }

    private void Update()
    {
        if (scoreToWin == 0)
        {
            RestartGame();
        }
        
        scoreText.text = $"To WIN: {scoreToWin}";
        appleText.text = $"Apples: {PlayerPrefs.GetInt("Apple")}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
