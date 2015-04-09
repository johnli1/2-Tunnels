using UnityEngine;
using System;
using System.IO;

public class FileReader {

	public static string filePath = @"/Users/johni/Desktop/a";
	
	public static byte[] readFile() {

		byte[] buf = null;
		try {
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			buf = new byte[fs.Length];
			fs.Read(buf, 0, (int)fs.Length);
		} catch (FileNotFoundException) {
			Debug.Log ("Problem opening file");
		}

		return buf;
	}
}
