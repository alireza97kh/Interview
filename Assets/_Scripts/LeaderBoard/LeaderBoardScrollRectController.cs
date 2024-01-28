using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class LeaderBoardScrollRectController : MonoBehaviour, LoopScrollPrefabSource, LoopScrollDataSource
{
    [SerializeField] private LeaderBoardItemController leaderBoardItemPrefab;
	[SerializeField] private LoopScrollRect leaderBoardScroller;
	private List<Member> leaderBoardMemeber = new List<Member>();
	private Stack<Transform> pool = new Stack<Transform>();
	public GameObject GetObject(int index)
	{
		if (pool.Count == 0)
		{
			return Instantiate(leaderBoardItemPrefab).gameObject;
		}
		Transform candidate = pool.Pop();
		candidate.gameObject.SetActive(true);
		return candidate.gameObject;
	}
	public void ReturnObject(Transform trans)
	{
		trans.SendMessage("ScrollCellReturn", SendMessageOptions.DontRequireReceiver);
		trans.gameObject.SetActive(false);
		trans.SetParent(transform, false);
		pool.Push(trans);
	}
	public void Init(List<Member> _leaderBoardMemeber)
    {
		leaderBoardMemeber = _leaderBoardMemeber;
		leaderBoardScroller.prefabSource = this;
		leaderBoardScroller.dataSource = this;
		leaderBoardScroller.totalCount = leaderBoardMemeber.Count;
		leaderBoardScroller.RefillCells();
	}

	public void ProvideData(Transform transform, int idx)
	{
		if (transform.gameObject.activeInHierarchy)
		{
			transform.SendMessage("SetMemberData", leaderBoardMemeber[idx]);
		}
		
	}
}
