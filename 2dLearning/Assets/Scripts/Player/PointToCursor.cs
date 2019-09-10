using UnityEngine;

public class PointToCursor : MonoBehaviour {
    Vector3 axis = new Vector3(0f, 0f, 1f);
    void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion rotat = Quaternion.AngleAxis(angle, axis);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotat, 10 * Time.deltaTime);
    }
}
