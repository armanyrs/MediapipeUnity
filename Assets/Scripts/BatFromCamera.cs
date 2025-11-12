using UnityEngine;
public class BatFromCamera : MonoBehaviour
{
    public CameraReceiver receiver; // drag object yang punya CameraReceiver
    public float worldMinY = -4f; // batas bawah
    public float worldMaxY = 4f; // batas atas
    public float smooth = 8f; // perhalus gerakan

    void Update()
    {
        if (receiver == null) return;

        float t = receiver.normalizedY;
        float targetY = Mathf.Lerp(worldMinY, worldMaxY, 1f - t);
        Vector3 p = transform.position;
        p.y = Mathf.Lerp(p.y, targetY, Time.deltaTime * smooth);
        transform.position = p;
    }
}