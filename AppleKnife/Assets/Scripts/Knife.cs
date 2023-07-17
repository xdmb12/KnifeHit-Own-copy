using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pie"))
        {
            _gameManager.scoreToWin -= 1;
            _gameManager._pieManager.speed *= 1.2f;
            
            rb.isKinematic = true;
            transform.SetParent(other.transform);
        }
        
        if (other.gameObject.CompareTag("Knife"))
        {
            _gameManager.RestartGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("apple"))
        {
            PlayerPrefs.SetInt("Apple", PlayerPrefs.GetInt("Apple") + 1);
            other.gameObject.SetActive(false);
        }
    }
}
