using UnityEngine;

namespace Simple
{
    public abstract class SimpleMenu : MonoBehaviour
	{
		public Transform menuOptionsTransform;
		protected SimpleMenuOption[] menuOptions;

		protected virtual void Start()
		{
			GetOptions();
		}

		private void GetOptions()
		{
			if (menuOptionsTransform == null)
			{
				return;
			}

			menuOptions = menuOptionsTransform.GetComponentsInChildren<SimpleMenuOption>(true);
		}

		protected SimpleMenuOption GetMenuOption(string menuOptionString)
		{
			for (int i = 0; i < menuOptions.Length; i++)
			{
				if (menuOptions[i].optionName == menuOptionString)
				{
					return menuOptions[i];
				}
			}
			return null;
		}
	}
}
