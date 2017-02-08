using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandManager : MonoBehaviour {

    bool isCalibration = false;
    public List<GameObject> renderMesh;
    public void CalibrationEnable() {
        isCalibration = !isCalibration;

        foreach (var mesh in renderMesh)
            mesh.GetComponent<RenderMesh>().IsHide = isCalibration;
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

    public GameObject cameraDegreeText;
    public void CameraDegreeOnValueChanged(float value) {
        GameObject.Find("ScriptManager").GetComponent<CameraPositionController>().Degree = value;
        var text = "CameraDegree(" + string.Format("{0:f2}", value) + ")";
        cameraDegreeText.GetComponent<UnityEngine.UI.Text>().text = text;
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

    void OnGUI() {
        var mousePos = Display.RelativeMouseAt (Input.mousePosition);
        GUI.Label(new Rect(10, 10, 200, 20), "mouse position:" + ((Vector2)mousePos).ToString());
        GUI.Label(new Rect(10, 30, 200, 20), "display id:" + mousePos.z);
    }
}
