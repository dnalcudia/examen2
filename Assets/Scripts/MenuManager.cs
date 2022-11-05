using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	
	public void MainMenu()
	{
		SceneManager.LoadScene("StartScreen");
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}
	
	public void CreditsScene()
	{
		SceneManager.LoadScene("CreditsScene");
	}
	
	public void ExitGame()
	{
		
		if(Application.isEditor)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
		else
		{
			Application.Quit();
		}
	}
}
