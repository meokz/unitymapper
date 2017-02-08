using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class RenderMesh : MonoBehaviour {

    public int projecterNo;
    public GameObject controllerPrefab;
    List<GameObject> controllerList;
    public Camera projecter;

    Vector3[] vertices;
    Mesh _mesh;

    bool isHide = false;
    public bool IsHide {
        get { return isHide; }
        set {
            foreach(var cntr in controllerList) {
                cntr.SetActive(value);
            }
            isHide = value;
        }
    }

    void Start() {
        // Meshの頂点を取得
        _mesh = GetComponent<MeshFilter>().mesh;
        vertices = _mesh.vertices;

        // SaveFileがあれば読み込む
        if (IsFileExists()) Load();

        controllerList = new List<GameObject>();
        for (int i = 0; i < vertices.Length; i++) { 
            // 頂点の座標にマッピング用のコントローラを作る
            var instance = GameObject.Instantiate(controllerPrefab, this.transform, false) as GameObject;
            instance.transform.localPosition = vertices[i];
            instance.name = i.ToString();
            // コントローラに付いてるscriptを取ってくる
            var renderMeshController = instance.GetComponent<RenderMeshController>();
            renderMeshController.projecter = this.projecter;
            // コントローラの位置が変わったときのイベントを設定
            renderMeshController.OnPositionChanged += RenderMeshController_OnPositionChanged;
            controllerList.Add(instance);
        }

        this.IsHide = false;
    }

    RenderMeshController holdObject;
    float distance = 100.0f;
    void Update() {
        var mousePos = Display.RelativeMouseAt(Input.mousePosition);
        // マウスカーソルのあるプロジェクタと違ったら処理しない
        if(projecterNo != mousePos.z) return;

        if (Input.GetMouseButtonDown(0)) {
            // Rayの生成
            var ray = this.projecter.ScreenPointToRay((Vector2)mousePos);
            var hit = new RaycastHit();
            // Rayとオブジェクトの当たり判定
            if (Physics.Raycast(ray, out hit, distance)) {
                holdObject = hit.collider.gameObject.GetComponent<RenderMeshController>();
                holdObject.MouseDown(mousePos);
            }
        } else if (Input.GetMouseButtonUp(0)) {
            if (holdObject != null) {
                holdObject.MouseUp();
                holdObject = null;
            }
        } else {
            if (holdObject != null) {
                holdObject.MouseDrag(mousePos);
            }
        }
    }

    private void RenderMeshController_OnPositionChanged(object sender, RMControllerEventArgs e) {
        // 頂点の位置 = コントローラの移動後の座標
        vertices[e.id] = e.position;
        _mesh.vertices = vertices;
        _mesh.RecalculateBounds();

        Save();
    }

    bool IsFileExists() {
        var path = Application.dataPath + "/../" + "Projecter" + projecterNo + ".txt";
        return File.Exists(path);
    }

    void Save() {
        var fileInfo = new FileInfo(Application.dataPath + "/../" + "Projecter" + projecterNo + ".txt");

        using (StreamWriter sw = fileInfo.CreateText()) {
            for (int i = 0; i < vertices.Length; i++) {
                sw.Write(vertices[i].x + " ");
                sw.Write(vertices[i].y + " ");
                sw.WriteLine(vertices[i].z);
            }
            sw.Flush();
        }
    }

    void Load() {
        var fileInfo = new FileInfo(Application.dataPath + "/../" + "Projecter" + projecterNo + ".txt");
        using (StreamReader sr = fileInfo.OpenText()) {
            for (int i = 0; i < vertices.Length; i++) {
                var line = sr.ReadLine();
                var block = line.Split(' ');
                vertices[i].x = float.Parse(block[0]);
                vertices[i].y = float.Parse(block[1]);
                vertices[i].z = float.Parse(block[2]);
            }
        }

        _mesh.vertices = vertices;
        _mesh.RecalculateBounds();
    }
}
