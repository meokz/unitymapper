using UnityEngine;
using System.Collections;

public class InverteCameraTexture : MonoBehaviour {
    private Matrix4x4 mat;
    Camera _camera;

    void Start() {
        // プロジェクタからそのまま映像を投影すると左右反転で映ってしまうので
        // Unity側からあらかじめ映像を反転させて投影します．
        _camera = this.GetComponent<Camera>();
        mat = _camera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }

    void OnPreCull() {
        _camera.ResetWorldToCameraMatrix();
        _camera.ResetProjectionMatrix();
        _camera.projectionMatrix = mat;
    }

    void OnPreRender() {
        GL.invertCulling = true;
    }

    void OnPostRender() {
        GL.invertCulling = false;
    }
}
