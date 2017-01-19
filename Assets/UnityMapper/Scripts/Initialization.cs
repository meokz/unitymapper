using UnityEngine;
using Leap;

public class Initialization : MonoBehaviour {

    void Awake() {
        Screen.SetResolution(1280, 720, false);

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
