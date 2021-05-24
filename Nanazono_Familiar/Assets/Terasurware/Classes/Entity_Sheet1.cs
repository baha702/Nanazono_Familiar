using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Sheet1 : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string Hira_kake2;
		public string Hira_kake3;
		public string Hira_kake4;
		public string Hira_kake5;
		public string Hira_kake6;
		public string Hira_yominikui3;
		public string Hira_yominikui4;
		public string Hira_yominikui5;
		public string Hira_boss10;
		public string Hira_boss11;
		public string Hira_boss12;
		public string Hira_boss13;
	}
}

