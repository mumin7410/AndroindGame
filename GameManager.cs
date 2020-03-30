﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameObject gameOverCanvas;
   public GameObject StartCanvas;
   private void Start()
   {
       Time.timeScale = 1 ;
   }
   public void GameOver()
   {
       gameOverCanvas.SetActive(true);
       Time.timeScale = 0;
   }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}