using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoading : MonoBehaviour 
{
	[SerializeField]
	private Image _progressBar;
	
	// Use this for initialization
	void Start()
	{
		//start async operation		
		StartCoroutine(LoadAsyncOperation());
	}
	
	IEnumerator LoadAsyncOperation()
	{
		//create an async operation
		AsyncOperation gameLevel = SceneManager.LoadSceneAsync(4);
		
		while (gameLevel.progress < 1)
		{
			//take the progress bar fill = async operation progress.
			_progressBar.fillAmount = gameLevel.progress;
			yield return new WaitForEndOfFrame();
		}
			
	}
	
}
