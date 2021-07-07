using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class NameList_Hiragana_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Resources/NameList_Hiragana.xlsx";
	private static readonly string exportPath = "Assets/Resources/NameList_Hiragana.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_Sheet1 data = (Entity_Sheet1)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_Sheet1));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_Sheet1> ();
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

					Entity_Sheet1.Sheet s = new Entity_Sheet1.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_Sheet1.Param p = new Entity_Sheet1.Param ();
						
					cell = row.GetCell(0); p.Hira_kake2 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.Hira_kake3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.Hira_kake4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.Hira_kake5 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.Hira_kake6 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.Hira_yominikui3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.Hira_yominikui4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.Hira_yominikui5 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(8); p.Hira_boss10 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(9); p.Hira_boss11 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(10); p.Hira_boss12 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(11); p.Hira_boss13 = (cell == null ? "" : cell.StringCellValue);
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
