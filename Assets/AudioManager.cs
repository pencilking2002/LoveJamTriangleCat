using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public enum Clip
	{	
		MenuAudio,
		ParkAmbient,

		TileSelect,
		Bump,
		Click,
		CodeWrong,
		CodePartial,
		CodeSuccess,
		Win
	}

	public Dictionary<Clip, AudioClip> audioClipDict;

	public static AudioManager Instance;

	[Header("Music/Ambient")]
	public AudioClip ambientParkAudio;
	public AudioClip menuAudio;

	[Header("Effects")]
	public AudioClip tileSelectAudio;
	public AudioClip[] bumps = new AudioClip[3];
	public AudioClip[] codeClicks = new AudioClip[5];
	public AudioClip codePartial;
	public AudioClip codeSuccess;
	public AudioClip codeWrong;
	public AudioClip winAudio;

	//public digc

	public AudioSource musicSource;
	public AudioSource effectsSource;

	// Use this for initialization
	void Awake () {

		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		audioClipDict = new Dictionary<Clip, AudioClip>()
		{
			{Clip.MenuAudio, menuAudio},
			{Clip.ParkAmbient, ambientParkAudio},
			{Clip.TileSelect, tileSelectAudio},
			{Clip.Bump, bumps[0]},
			{Clip.Click, codeClicks[0]},
			{Clip.CodeSuccess, codePartial},
			{Clip.CodePartial, codeSuccess},
			{Clip.CodeWrong, codeWrong},
			{Clip.Win, winAudio}
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMusic(Clip c)
	{
		musicSource.PlayOneShot(audioClipDict[c]);

	}

	public void PlayEffect(Clip c)
	{
		effectsSource.PlayOneShot(audioClipDict[c]);
	}



}
