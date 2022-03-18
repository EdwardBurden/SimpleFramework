using UnityEngine;


namespace Simple
{
    public class MainMenu : SimpleMenu
	{
		public string mainGameSceneName;

		public void OpenGameScene()
		{
			SceneController.Instance.OpenGameScene();
			SceneController.Instance.CloseMainMenuScene();
		}

		public void OpenSettings()
		{
			//Close a panel and open a new one settings is a menu element not a scene
		}

		public void Close()
		{
			Application.Quit();
		}
	}
}
