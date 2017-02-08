using System.IO;
using System.Text;
using UnityEngine;
using System.Collections;

public class Util {
    public static void Log(string str) {
        var fileInfo = new FileInfo(Application.dataPath + "/../" + "Log.txt");
        using (StreamWriter sw = fileInfo.AppendText()) {
            sw.WriteLine(str);
            sw.Flush();
        }
    }
}
