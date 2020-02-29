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
	public AudioClip cheer, lose;

    private bool gameIsOver;
    private float score;
    private int bulletCount;
	private AudioSource audioSource;

	private Coroutine scoreRoutine;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Start()
    {
        TimeManager.Initialize();
		scoreRoutine = StartCoroutine(ScoreTick());
    }

    private void Update()
    {
        HandleInput();
        levelText.text = "Score: " + ((int)(score*10)).ToString();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void AddToBulletCount()
    {
		if (!gameIsOver)
		{
			bulletCount++;
			audioSource.PlayOneShot(cheer);
		}
	}

    public void GameOver()
    {
        loseText.SetActive(true);
        gameIsOver = true;
		audioSource.PlayOneShot(lose);
		if (scoreRoutine != null)
			StopCoroutine(scoreRoutine);
	}

    private IEnumerator ScoreTick()
    {
        do
        {
            score += (levelMaker.levelNumber + bulletCount) * Time.deltaTime;
            yield return new WaitForSecondsRealtime(1);
        } while (true);
    }

	public void ReturnToMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(1);
	}
}
