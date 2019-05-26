using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        yield return new WaitForSeconds(.8f);

        Vector3 originalPos = transform.localPosition;
        float ellipsed = 0.0f;
        while(ellipsed<duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);

            ellipsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
