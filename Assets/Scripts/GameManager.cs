using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject loseText;

	private bool gameIsOver;

    void Start()
    {
        TimeManager.Initialize();
    }

	private void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene(0);
		}

	}

	public void StartGame()
    {

    }

    public void GameOver()
    {
		loseText.SetActive(true);
		gameIsOver = true;
	}
}
