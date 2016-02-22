using UnityEngine;
using System.Collections;

public class LightAlarm : MonoBehaviour {
    public GameObject[] Lights = new GameObject[4];

    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;

    private float targetIntensity;
    private bool AlarmActive = false;
    void OnEnable()
    {
        EventMan.isPlayerSpotted += AlarmOn;
    }
    void OnDisable()
    {
        EventMan.isPlayerSpotted -= AlarmOn;
    }
    void Awake () {
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].GetComponent<Light>().intensity = 0f;
        }
        targetIntensity = highIntensity;
    }

    // Update is called once per frame
    void Update() {
       if(GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<EventMan>().ActiveAlarm == false)
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].GetComponent<Light>().intensity = Mathf.Lerp(Lights[i].GetComponent<Light>().intensity, 0f, fadeSpeed * Time.deltaTime);
            }
        }

	}

    void AlarmOn()
    {
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].GetComponent<Light>().intensity = Mathf.Lerp(Lights[i].GetComponent<Light>().intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity(Lights[i]);
        }
    }
    public void CheckTargetIntensity(GameObject Light)
    {

        if (Mathf.Abs(targetIntensity - Light.GetComponent<Light>().intensity) < changeMargin)
        {

            if (targetIntensity ==highIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else {
                targetIntensity = highIntensity;
            }
        }
    }
}
