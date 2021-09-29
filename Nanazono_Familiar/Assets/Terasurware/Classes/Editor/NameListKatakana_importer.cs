using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class NameListKatakana_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Resources/NameListKatakana.xlsx";
	private static readonly string exportPath = "Assets/Resources/NameListKatakana.asset";
	private static readonly string[] sheetNames = { "Katakana", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_Katakana data = (Entity_Katakana)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_Katakana));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_Katakana> ();
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

					Entity_Katakana.Sheet s = new Entity_Katakana.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_Katakana.Param p = new Entity_Katakana.Param ();
						
					cell = row.GetCell(0); p.kake2 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.kake3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.kake4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.kake5 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.kake6 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.yominikui3 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.yominikui4 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.yominikui5 = (cell == null ? "" : cell.StringCellValue);
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
