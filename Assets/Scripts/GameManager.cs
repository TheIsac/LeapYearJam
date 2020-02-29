using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject loseText;

    void Start()
    {
        TimeManager.Initialize();
    }

    public void StartGame()
    {

    }

    public void GameOver()
    {
		loseText.SetActive(true);
	}
}
