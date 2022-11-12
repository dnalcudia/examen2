using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KillCount : MonoBehaviour
{
	
	public int KillCounter =0;
	public TMP_Text TKC;
	public GameObject Door1,Door2;
	

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	void Start()
	{
		KillCounter = 0;	
	}
	
    void Update()
    {
	    Debug.Log(KillCounter);
	    TKC.text = "Kill Count: " + KillCounter.ToString();
	    
	    if (KillCounter >= 10)
	    {
	    	Door1.SetActive(false);
	    }
	    
	    if (KillCounter >= 25)
	    {
	    	Door2.SetActive(false);
	    }
	    
	    if(KillCounter >= 50)
	    {
	    	SceneManager.LoadScene("WinScreen");
	    }
	    
    }
}
