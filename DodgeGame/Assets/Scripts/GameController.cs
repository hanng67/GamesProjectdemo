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
	private int gamePoint;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		audio = gameObject.GetComponent<AudioSource>();
		pnlEndGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetPoint()
    {
		gamePoint++;
		txtPoint.text = "Point: " + gamePoint.ToString();
    }

	public void ButtonHover()
    {
		btnRestart.GetComponent<Image>().sprite = btnRestartHover;
	}

	public void ButtonIdle()
	{
		btnRestart.GetComponent<Image>().sprite = btnRestartIdle;
	}

	public void ButtonClick()
	{
		btnRestart.GetComponent<Image>().sprite = btnRestartClick;
	}

	public void StartGame()
    {
		SceneManager.LoadScene(0);
    }

	public void EndGame()
	{
		pnlEndGame.SetActive(true);
		audio.Play();
		Time.timeScale = 0;
    }
}
