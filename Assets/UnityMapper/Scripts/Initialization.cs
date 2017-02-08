using UnityEngine;
using Leap;

public class Initialization : MonoBehaviour {

    void Awake() {
        // 解像度の設定
        // ディスプレイと各プロジェクタの解像度は全て同じにしてください．
        // Screen.SetResolution(1280, 720, false);

        // Leap Motionの起動
        var cntr = new Controller();
        if (cntr != null) {
            cntr.Config.Set<bool>("tracking_processing_auto_flip", false, delegate (bool success) {
                if (success) {
                    // 成功したとき
                }
            });
        }
    }
}
