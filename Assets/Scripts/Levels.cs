using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{//	b
	idle,
	playing,
	levelEnd
}
public class Levels : MonoBehaviour
{
	static private Levels S; //	a	private	Singleton
	[Header("Set in	Inspector")]
	public Text uitLevel; //	The	UIText_Level	Text
	public Text uitShots; //	The	UIText_Shots	Text
	public Text uitButton; //	The	Text	on	UIButton_View
	public Vector3 levelPos; //	The	place	to	put	setups
	public GameObject[] setups;            //	An	array	of	the	setups/levels

	[Header("Set Dynamically")]
	public int level;                   //	The	current	level
	public int levelMax;        //	The	number	of	levels
	public int shotsTaken;
	public GameObject setup;               //	The	current	castle
	public GameMode mode = GameMode.idle;
	
	void Start()
	{
		S = this; //	Define	the	Singleton
		level = 0;
		levelMax = setups.Length;
		StartLevel();
	}
	void StartLevel()
	{
		
		//	Instantiate	the	new	setup
		setup = Instantiate<GameObject>(setups[level]);
		//setup.transform.position = levelPos;
		shotsTaken = 0;
		
		//	Reset	the	goal
		Goal.goalMet = false;
		UpdateGUI();
		mode = GameMode.playing;
	}
	void UpdateGUI()
	{
		//	Show	the	data	in	the	GUITexts
		uitLevel.text = "Level:	" + (level + 1) + " of " + levelMax;
		uitShots.text = "Shots Taken: " + shotsTaken;
	}
	void Update()
	{
		UpdateGUI();
		//	Check	for	level	end
		if ((mode == GameMode.playing) && Goal.goalMet)
		{
			//	Change	mode	to	stop	checking	for	level	end
			mode = GameMode.levelEnd;

			//	Start	the	next	level	in	2	seconds
			Invoke("NextLevel", 2f);
		}
	}
	void NextLevel()
	{
		level++;
		if (level == levelMax)
		{
			level = 0;
		}
		StartLevel();
	}

	public static void ShotFired()
	{//	d
		S.shotsTaken++;
	}
}
