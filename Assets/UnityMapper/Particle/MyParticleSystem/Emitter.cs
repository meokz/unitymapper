using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

    public GameObject particlePrefab;
    // 生成する間隔 
    public int interval = 1; 
    // 生成する個数 
    public int time = 1; 
    // 生成する範囲 
    public float redius = 3.0f; 
    // 生成する大きさ 
    public float scale_min = 0.3f; 
    public float scale_max = 0.6f; 

    private int _interval = 0;
	void Update () {
        if (_interval++ >= interval) {
            for(int i = 0; i <= time; i++) {
                emmit();
            }
            _interval = 0;
        }
	}

    void emmit() {
        // 半径内のランダムな場所にParticle生成
        var _redius = Random.Range(0.0f, redius);
        var theta = Random.Range(0, 360) * Mathf.PI / 180;
        var x = _redius * Mathf.Cos(theta);
        var y = this.transform.position.y;
        var z = _redius * Mathf.Sin(theta);

        var particle = Instantiate(
            particlePrefab, 
            new Vector3(x, y, z),
            Quaternion.identity) as GameObject;

        // 大きさをランダムで変える
        var scale = Random.Range(scale_min, scale_max);
        particle.transform.localScale = new Vector3(scale, scale, scale);

        particle.gameObject.name = "particle";
        // Particleの親にEmitterを登録
        particle.transform.parent = this.transform;
    }
}
