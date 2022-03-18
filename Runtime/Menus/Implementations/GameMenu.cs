namespace Simple
{
    public class GameMenu : SimpleMenu
    {

        public void Pause()
        {
            GetMenuOption("Resume").gameObject.SetActive(true);
            GetMenuOption("Pause").gameObject.SetActive(false);
            PauseControl.Pause();
        }

        public void Resume()
        {
            GetMenuOption("Resume").gameObject.SetActive(false);
            GetMenuOption("Pause").gameObject.SetActive(true);
            PauseControl.Resume();
        }

        public void ReturnToMainMenu()
        {
            SceneController.Instance.OpenMainMenuScene();
            SceneController.Instance.CloseGameScene();
        }
    }
}