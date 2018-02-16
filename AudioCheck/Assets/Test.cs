using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class Test : MonoBehaviour
{
    public GameObject circle;
    int k = 16; //16 checks
    float position = -8;
    public float maxValueToCheck = 1;

    public float[] spectrum = new float[256];

    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < k ; i++)
        {
            spawnCircleIfNeeded(spectrum, k * i, k + k*i);
            position += 1;

            if (position > 8f) position = -8f;
        }
    }

    void spawnCircleIfNeeded(float[] spectrum, int startIndex, int endIndex)
    {
        float totalSum = 0;

        for (; startIndex < endIndex; startIndex++)
        {
            totalSum += spectrum[startIndex];
        }

        if (totalSum > maxValueToCheck)
        {
            GameObject myCircle;
            myCircle = Instantiate(circle);

            myCircle.transform.position = new Vector3(position, myCircle.transform.position.y, myCircle.transform.position.z);
        }
            

    }
}