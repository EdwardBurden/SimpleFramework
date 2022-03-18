using Simple;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private void Awake()
	{

	}

	private void Start()
	{
		SceneController.Instance.OpenMainMenuScene();
	}
}
