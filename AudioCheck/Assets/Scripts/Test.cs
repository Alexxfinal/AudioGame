using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class Test : MonoBehaviour
{
    int k = 16; //16 checks
    int spawns = 0;
    float position = -8;
    public float maxValueToCheck = 1;

    public float[] spectrum = new float[256];

    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        spawns = 0;

        for (int i = 0; i < k ; i++)
        {
            spawnCircleIfNeeded(spectrum, k * i, k + k*i);
            position += 1;

            if (position > 8f) position = -8f;
        }
    }

    public void setValue(float value)
    {
        maxValueToCheck = value;
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
            spawns += 1;

            if (spawns >= k)
            {
                return;
            }

            GameObject myCircle;
            myCircle = GenericPool.current.GetPooledObject();
            myCircle.SetActive(true);

            myCircle.transform.position = new Vector3(position, 7.33f, myCircle.transform.position.z);
        }
            

    }
}