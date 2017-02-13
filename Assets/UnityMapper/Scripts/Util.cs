using System.IO;
using System.Text;
using UnityEngine;
using System.Collections;

public class Util {

    public static void Log(string str) {
        // Unityを最大表示にする都合上，
        // デバッグ用ログを出力しづらいので，
        // この関数を使用してファイル上にログを書きます．
        var fileInfo = new FileInfo(Application.dataPath + "/../" + "Log.txt");
        using (StreamWriter sw = fileInfo.AppendText()) {
            sw.WriteLine(str);
            sw.Flush();
        }
    }
}
