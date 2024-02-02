using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LeaderBoardData", menuName = "Data/LeaderBoardData")]
public class LeaderBoardData : ScriptableObject
{
    public List<LeaderBoardAvararClass> leaderBoardAvararsClass = new List<LeaderBoardAvararClass>(); // this is just for show in inspector no more
    public Sprite defaultAvatar;

    public Dictionary<int, LeaderBoardAvararClass> leaderBoardAvatars = new Dictionary<int, LeaderBoardAvararClass>();

    public Sprite GetAvatar(int avatarId)
    {
        if (avatarId > leaderBoardAvatars.Count)
            avatarId %= leaderBoardAvatars.Count;

        if (leaderBoardAvatars.TryGetValue(avatarId, out LeaderBoardAvararClass avatar))
            return avatar.avatarSprite;

        return defaultAvatar;
    }


    public List<LeaderBoardFrameClass> leaderBoardFrameClasses = new List<LeaderBoardFrameClass>();
	public Sprite defaultFrame;
	public Dictionary<int, LeaderBoardFrameClass> leaderBoardFrames = new Dictionary<int, LeaderBoardFrameClass>();

    public Sprite GetFrame(int frameId)
    {
        if (frameId > leaderBoardFrames.Count)
            frameId %= leaderBoardFrames.Count;

		if (leaderBoardFrames.TryGetValue(frameId, out LeaderBoardFrameClass frame))
			return frame.frameSprite;

        return defaultFrame;
	}

}
