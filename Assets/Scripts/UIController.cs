using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

	public TMP_Text Score;
	public TMP_Text Health;

	[SerializeField] private StartSetup_SO _startSetup_SO;
	[SerializeField] private EventController _eventController;

	[SerializeField] private GameObject _menu;
	[SerializeField] private GameObject _player;

	[SerializeField] private Button[] _buttons;

	private UIInput _UIInput;
	public int NowHP = 3;
	private int _nowScore = 0;
	private int _playerChoice;

	public int PlayerChoice => _playerChoice;

    private void Start()
    {
		_UIInput = GetComponent<UIInput>();
		_eventController = GetComponent<EventController>();
		ShowMenu(true, false);
    }

    //////////////////////////////


    public void HealthCounter(int HP)
	{
		NowHP = HP;
		Health.text = "Health:  " + NowHP.ToString();
	}

	public void ScoreCounter(int points)
	{
		_nowScore += points;
		Score.text = "Score:  " + _nowScore.ToString();
	}

	private void Reset()
	{
		_eventController.Reset();

		NowHP = _startSetup_SO.HP;
		_nowScore = _startSetup_SO.Score;

		HealthCounter(NowHP);
		ScoreCounter(_nowScore);

		_player.transform.position = new Vector3(0, 0, 0);
		_player.transform.rotation = new Quaternion(0, 0, 0, 0);
	}


	//////////////////////////////

	public void ShowMenu(bool isActive, bool isPlaying)
	{
		_UIInput.ShowMenu = isActive;
		_player.SetActive(!isActive);
		if (isActive)
		{
			_menu.SetActive(isActive);
			Time.timeScale = 0f;
		}
		else if (!isActive)
		{
			_menu.SetActive(isActive);
			Time.timeScale = 1f;
		}

		if (isPlaying)
		{
			_buttons[0].interactable = true;
		}
		else if (!isPlaying)
		{
			_buttons[0].interactable = false;
		}
	}

	public void Resume()
	{
		ShowMenu(false, true);
	}

	public void NewGame()
	{
		ShowMenu(false, true);

		Reset();
	}

	public void SwitchInput(int num)
	{
		_playerChoice = num;
	}

	public void QuitApp()
	{
		Application.Quit();
	}
}
