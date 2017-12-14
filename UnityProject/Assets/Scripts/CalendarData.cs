using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CalendarData {

	public List<DayData> DayArray = new List<DayData>();
	
	public CalendarData DeepCopy( CalendarData data)
	{
		CalendarData newData = new CalendarData ();
		newData.DayArray = data.DayArray;
		return newData;
	}
}
