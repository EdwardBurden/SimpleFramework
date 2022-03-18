namespace Simple
{
    public class LoadingMenu : SimpleMenu
	{
		//only handle ui
		protected override void Start()
		{
			SceneLoader.updateLoadPercentage += SceneLoader_loadPercent;
			base.Start();
		}

		public void OnDestroy()
		{
			SceneLoader.updateLoadPercentage -= SceneLoader_loadPercent;
		}

		private void SceneLoader_loadPercent(float obj)
		{
			//	throw new System.NotImplementedException();
		}

	}
}
