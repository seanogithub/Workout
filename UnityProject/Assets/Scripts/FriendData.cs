using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FriendData {

	public string ScreenName = "ScreenName";
	public string Email = "Email";
	public bool RequestSent = false;
	public bool RequestAccepted = false;

	public FriendData DeepCopy( FriendData data)
	{
		FriendData newData = new FriendData ();
		newData.ScreenName = data.ScreenName;
		newData.Email = data.Email;
		newData.RequestSent = data.RequestSent;
		newData.RequestAccepted = data.RequestAccepted;
		return newData;
	}
}
