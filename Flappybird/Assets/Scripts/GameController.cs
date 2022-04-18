using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public bool isEndGame;
	private bool isStartFirstGame;
	private int gamePoint = 0;
	public Text txtPoint;
	public GameObject pnlEndGame;
	public Text txtEndPoint;
	public Button btnRestart;


	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		isEndGame = false;
		isStartFirstGame = true;
		pnlEndGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isEndGame)
		{
			if (Input.GetMouseButton(0) && isStartFirstGame)
			{
				StartGame();
			}
        }
        else
        {
			if (Input.GetMouseButton(0))
			{
				Time.timeScale = 1;
			}
		}

	}

	public void ButtonRestartIdle()
    {
		btnRestart.GetComponent<Image>().color = Color.white;
    }

	public void ButtonRestartHover()
    {
		btnRestart.GetComponent<Image>().color = Color.yellow;
	}

	public void ButtonRestartClick()
    {
		btnRestart.GetComponent<Image>().color = Color.black;
	}

	void StartGame()
    {
		SceneManager.LoadScene(0);
	}

	public void RestartGame()
    {
		StartGame();
    }

	public void GetPoint()
	{
		gamePoint++;
		txtPoint.text = "Point: " + gamePoint.ToString();
	}

	public void EndGame()
    {
		isEndGame = true;
		isStartFirstGame = false;
		pnlEndGame.SetActive(true);
		txtEndPoint.text = "Your Point: " + gamePoint.ToString();
		Time.timeScale = 0;

	}
}
