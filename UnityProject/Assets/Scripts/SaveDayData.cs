using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveDayData {

//	public List<DayData> UserDayData = new List<DayData>();
	public DayData[] Day = new DayData[0];

	public SaveDayData()
	{
//		UserDayData = new List<DayData>();
		Day = new DayData[0];
	}

	public void Add (DayData newItem)
	{
		DayData[] tempArray = new DayData[Day.Length+1];
		if (Day.Length > 0)
		{
			for(int i = 0; i < Day.Length; i++)
			{
				tempArray[i] = Day[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			Day = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Day = tempArray;
		}
	}
	
	public void Insert (int Index, DayData newItem)
	{
		if (Index > Day.Length || Index < 0) 
		{
			Index = Day.Length-1;
		}
		
		DayData[] tempArray = new DayData[Day.Length+1];
		if (Day.Length > 0)
		{
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Day[i];
			}
			
			tempArray[Index] = newItem;
			
			for(int i = Index+1; i < Day.Length+1; i++)
			{
				tempArray[i] = Day[i-1];
			}
			Day = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Day = tempArray;
		}
	}
	
	public void RemoveAt (int Index)
	{
		if(Day.Length > 0)
		{
			DayData[] tempArray = new DayData[Day.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Day[i];
			}
			for(int i = Index + 1; i < Day.Length; i++)
			{
				tempArray[i-1] = Day[i];
			}
			Day = tempArray;
		}
	}
	
	public void Clear ()
	{
		Day = new DayData[0];
	}
}
