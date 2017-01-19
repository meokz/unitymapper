using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandManager : MonoBehaviour {

    bool isCalibration = false;
    public void CalibrationEnable() {
        isCalibration = !isCalibration;

        if (isCalibration)  SwitchCalibration();
        else {
            foreach (var mesh in renderMesh)
                mesh.GetComponent<RenderMesh>().IsHide = false;
        }
    }

    int calibration = 0;
    public List<GameObject> renderMesh;
    public void SwitchCalibration() {
        int display = Display.displays.Length;
        if (display != 1) display -= 1;
        else display = 1;

        for (int i = 0; i < display; i++) {
            if (i == calibration % display)
                renderMesh[i].GetComponent<RenderMesh>().IsHide = true;
            else renderMesh[i].GetComponent<RenderMesh>().IsHide = false;
        }
        calibration += 1;
    }

    bool isProjecter1 = false;
    public GameObject projecter1;
    public void ActivateProjecter1() {
        Display.displays[1].Activate();
    }

    bool isProjecter2 = false;
    public GameObject projecter2;
    public void ActivateProjecter2() {
        Display.displays[2].Activate();
    }

    bool isProjecter3 = false;
    public GameObject projecter3;
    public void ActivateProjecter3() {
        Display.displays[3].Activate();
    }

    public GameObject _light;
    public void LightIntencyOnValueChanged(float value) {
      _light.GetComponent<Light>().intensity = value * 2;
    }

    int count = 0;
    public List<GameObject> projectedObject;
    public void SwitchModelOnClick() {
        count += 1;
        for(int i = 0; i < projectedObject.Count; i++) {
            if(i == count % projectedObject.Count) {
                projectedObject[i].SetActive(true);
            } else {
                projectedObject[i].SetActive(false);
            }
        }
    }
}
