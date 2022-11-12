using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int time = 30;

    public int difficulty = 1;
	
	private static bool gameIsPaused;

	private void Awake()
    
    {
        if (Instance == null)
        {
            Instance = this;
        }        
    }

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        // Game Over
    }
    
	
	void PauseGame ()
	{
		if(gameIsPaused)
		{
			Time.timeScale = 0f;
		}
		else 
		{
			Time.timeScale = 1;
		}
	}
	
	void PauseLogic()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameIsPaused = !gameIsPaused;
			PauseGame();
		}
	}
	
	void Update()
	{
		PauseGame();
	}
    
}
