using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Katakana : ScriptableObject
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
		
		public string kake2;
		public string kake3;
		public string kake4;
		public string kake5;
		public string kake6;
		public string yominikui3;
		public string yominikui4;
		public string yominikui5;
	}
}

