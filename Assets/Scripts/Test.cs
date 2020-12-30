using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    bool GyroEnabled;
    Gyroscope Gyro;
    Quaternion Rot;
    GameObject CameraContainer;

    void Start()
    {
        CameraContainer = new GameObject("Camera Container");
        CameraContainer.transform.position = transform.position;
        transform.SetParent(CameraContainer.transform);
        GyroEnabled = EnableGyroscope();
    }

    bool EnableGyroscope()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Gyro = Input.gyro;
            Gyro.enabled = true;

            CameraContainer.transform.rotation = Quaternion.Euler(90f,90f,0f);
            Rot = new Quaternion(0,0,1,0);

            return true;
        }
        return false;
    }

    private void Update()
    {
        if(GyroEnabled)
        {
            transform.localRotation = Gyro.attitude * Rot;
        }
    }
}