using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject pnlEndGame;
	public Button btnRestart;
	public Sprite btnRestartIdle;
	public Sprite btnRestartHover;
	public Sprite btnRestartClick;
	public Text txtPoint;
	private int getPoint;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		getPoint = 0;
		pnlEndGame.SetActive(false);
	}

	public void GetPoint()
    {
		getPoint++;
		txtPoint.text = "Zombie Killed: " + getPoint.ToString();
    }

	public void EndGame()
    {
		pnlEndGame.SetActive(true);
		Time.timeScale = 0;
    }

	public void BtnRestartIdle()
    {
		btnRestart.GetComponent<Image>().sprite = btnRestartIdle;
	}

	public void BtnRestartHover()
	{
		btnRestart.GetComponent<Image>().sprite = btnRestartHover;
	}

	public void BtnRestartClick()
	{
		btnRestart.GetComponent<Image>().sprite = btnRestartClick;
	}

	public void RestartGame()
    {
		SceneManager.LoadScene(0);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
