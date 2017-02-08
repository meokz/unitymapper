using System;
using UnityEngine;

public class RMControllerEventArgs : EventArgs {

    public RMControllerEventArgs(int id, Vector3 position) {
        this.id = id;
        this.position = position;
    }

    public int id;
    public Vector3 position;
}

public class RenderMeshController : MonoBehaviour {

    public delegate void RMControllerEventHandler(object sender, RMControllerEventArgs e);
    public event RMControllerEventHandler OnPositionChanged;
    public Camera projecter;

    private Vector3 screenPoint;
    private Vector3 offset;

    bool isSelected = false;
    public bool IsSelected {
        get { return isSelected; }
        set {
            if (value) {
                this.GetComponent<Renderer>().material.color = Color.red;
            } else {
                this.GetComponent<Renderer>().material.color = Color.green;
            }
            isSelected = value;
        }
    }

    void Start() {
        this.IsSelected = false;
    }

    public void MouseDown(Vector2 mousePos) {
        this.IsSelected = true;

        //カメラから見たオブジェクトの現在位置を画面位置座標に変換
        screenPoint = projecter.WorldToScreenPoint(this.transform.position);

        offset = this.transform.position - projecter.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, 0));
    }

    public void MouseDrag(Vector2 mousePos) { 
        if (!this.IsSelected) return;

        //ドラッグ時のマウス位置をシーン上の3D空間の座標に変換する
        Vector3 currentScreenPoint = new Vector3(mousePos.x, mousePos.y, 0);

        //上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
        Vector3 currentPosition = projecter.ScreenToWorldPoint(currentScreenPoint) + offset;

        //オブジェクトの位置を変更する
        this.transform.position = currentPosition;
    }

    public void MouseUp() {
        this.IsSelected = false;

        if (OnPositionChanged != null) {
            OnPositionChanged(this, new RMControllerEventArgs(int.Parse(this.gameObject.name), this.transform.localPosition));
        }
    }
}
