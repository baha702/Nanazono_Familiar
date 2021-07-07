using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class NameList_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Resources/NameList.xlsx";
	private static readonly string exportPath = "Assets/Resources/NameList.asset";
	private static readonly string[] sheetNames = { "Katakana", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_NameList data = (Entity_NameList)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_NameList));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_NameList> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Entity_NameList.Sheet s = new Entity_NameList.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_NameList.Param p = new Entity_NameList.Param ();
						
					cell = row.GetCell(0); p.kake2 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.kake3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.kake4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.kake5 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.kake6 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.yominikui3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.yominikui4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.yominikui5 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(8); p.boss10 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(9); p.boss11 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(10); p.boss12 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(11); p.boss13 = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
