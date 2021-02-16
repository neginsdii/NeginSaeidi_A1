using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
	//void Start()
	//{
	//	//Set Cursor to not be visible
	//	Cursor.lockState = CursorLockMode.None;
	//	Cursor.visible = true;
	//}
	public bool activate = false;
	public void GoToMain()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
	}
	public void GoToStart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start", LoadSceneMode.Single);
	}
	public void ActivateScene()
	{
		activate = !activate;
	}
}
