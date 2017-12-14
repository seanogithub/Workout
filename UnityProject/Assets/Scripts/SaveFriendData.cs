using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveFriendData {

//	public List<FriendData> UserFriendData = new List<FriendData>();
	public FriendData[] Friend = new FriendData[0];

	public SaveFriendData()
	{
//		UserFriendData = new List<FriendData>();
		Friend = new FriendData[0];
	}

	public void Add (FriendData newItem)
	{
		FriendData[] tempArray = new FriendData[Friend.Length+1];
		if (Friend.Length > 0)
		{
			for(int i = 0; i < Friend.Length; i++)
			{
				tempArray[i] = Friend[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			Friend = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Friend = tempArray;
		}
	}

	
	public void RemoveAt (int Index)
	{
		if(Friend.Length > 0)
		{
			FriendData[] tempArray = new FriendData[Friend.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Friend[i];
			}
			for(int i = Index + 1; i < Friend.Length; i++)
			{
				tempArray[i-1] = Friend[i];
			}
			Friend = tempArray;
		}
	}
	
	public void Clear ()
	{
		Friend = new FriendData[0];
	}
}
