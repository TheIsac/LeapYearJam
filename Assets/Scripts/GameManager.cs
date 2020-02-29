using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject loseText;
	public TextMeshProUGUI levelText;
	public LevelMaker levelMaker;

	private bool gameIsOver;
	private float score;

    void Start()
    {
        TimeManager.Initialize();
		StartCoroutine(ScoreTick());
    }

	private void Update()
	{
		HandleInput();
		levelText.text = "Score: " + score.ToString();
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

	private IEnumerator ScoreTick()
	{
		do
		{
			score += levelMaker.levelNumber * Time.deltaTime;
			yield return new WaitForSecondsRealtime(1);
		} while (true);
	}
}
