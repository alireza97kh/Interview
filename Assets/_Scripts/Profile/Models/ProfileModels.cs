using System;

namespace Dobeil
{
	public class PlayerProfileClass
	{
		public string playerName;
		public int coin;
		public int gem;
		public int lastRewardIndex;
		public DateTime firstLoginTime;

		public PlayerProfileClass()
		{
			playerName = "Guest";
			coin = 0;
			gem = 0;
			lastRewardIndex = 0;
		}

		public PlayerProfileClass(string _playerName, int _coin, int _gem, int _lastRewardIndex)
		{
			playerName = _playerName;
			coin = _coin;
			gem = _gem;
			lastRewardIndex = _lastRewardIndex;
		}
	}
}