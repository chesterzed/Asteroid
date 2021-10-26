using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartSetup", menuName = "SO/StartSetup_SO", order = 51)]
public class StartSetup_SO : ScriptableObject
{
	//	Player
	[SerializeField] private int _HP = 3;

	//	EventController
	[SerializeField] private int _score = 0;

	//	Player
	public int HP => _HP;

	//	EventController
	public int Score => _score;
}
