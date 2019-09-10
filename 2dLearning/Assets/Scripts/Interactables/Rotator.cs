using UnityEngine;

public class Rotator : MonoBehaviour {
    public Vector3 rotation;
    public Transform[] children;

    void Update() {
        transform.Rotate (rotation * Time.deltaTime); 

        for (int i = 0; i < children.Length; i++) {
            children[i].transform.rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
        }
    }
}
