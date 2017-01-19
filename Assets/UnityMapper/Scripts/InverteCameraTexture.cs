using UnityEngine;
using System.Collections;

public class InverteCameraTexture : MonoBehaviour {
    private Matrix4x4 mat;
    Camera _camera;

    void Start() {
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
