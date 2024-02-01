namespace Dobeil
{
	public class PlayerProfileClass
	{
		public string playerName;
		public int coin;
		public int gem;

		public PlayerProfileClass()
		{
			playerName = "Guest";
			coin = 0;
			gem = 0;
		}

		public PlayerProfileClass(string _playerName, int _coin, int _gem)
		{
			playerName = _playerName;
			coin = _coin;
			gem = _gem;
		}
	}
}