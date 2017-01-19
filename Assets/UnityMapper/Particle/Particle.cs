using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

    public Color color;

    public float time = 2.0f;
    float _time = 0.0f;

    void Update() {
        // 時間経過で削除
        _time += Time.deltaTime;
        if (_time >= time) {
            Destroy(this.gameObject);
        }

        this.GetComponent<Rigidbody>().AddForce(Vector3.down * 10, ForceMode.Force);
	}

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name != "particle") {
            this.GetComponent<Renderer>().material.color = this.color;
            this.time += 2.0f;
        }
    }
}
