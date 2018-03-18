namespace TestGame.Main
{
	public static class WarningMessage 
	{
		public static string MoreThanOne<T>()
		{
			return "There is more than one " + typeof(T).Name;
		}

		public static string ThereIsNo<T>()
		{
			return "There is no " + typeof(T).Name;
		}
	}
}

