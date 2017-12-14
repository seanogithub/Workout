using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class UI_Music : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	
	public AudioClip SoundMusic;

	public bool PlayingMusicFlag = false;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}

		if (PlayingMusicFlag) 
		{ 
			AudioListener.pause = false;
		}
		else 
		{
			AudioListener.pause = true;
		}
	}
	
	public void Init()
	{
		Initialize = false;
		GetComponent<AudioSource>().Play();
		AudioListener.pause = true;
	}

	public void MusicPlayButtonPressed()
	{
		if (PlayingMusicFlag) 
		{ 
			PauseMusic();
		}
		else 
		{
			PlayMusic();
		}
	}

	public void ResetMusic()
	{
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().Play ();
		AudioListener.pause = true;
	}

	public void PlayMusic()
	{
		PlayingMusicFlag = true;
		AudioListener.pause = false;
	}

	public void PauseMusic()
	{
		PlayingMusicFlag = false;
		AudioListener.pause = true;
	}
}
