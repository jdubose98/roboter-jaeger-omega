using UnityEngine;
using System.Collections;

public class OutrightStolenCamScript : MonoBehaviour {

    Vector3 originPosition;
    Quaternion originRotation;

    float shake_decay = 0;
    float shake_intensity = 0;
 
 void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Shake"))
        {
            Shake();
        }
    }

    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
        }

        if (shake_intensity <= 0)
        {
            transform.position = originPosition;
            transform.rotation = originRotation;
        }
    }

    void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = .3f;
        shake_decay = 0.002f;
    }
}
