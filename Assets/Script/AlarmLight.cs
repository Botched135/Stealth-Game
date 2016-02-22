using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;

    private float targetIntensity;


    void Awake()
    {
        gameObject.GetComponent<Light>().intensity = 0f;
        targetIntensity = highIntensity;

    }
   

    void Update()
    {

        Debug.Log("Hey");
        //gameObject.GetComponent<Light>().intensity = Mathf.Lerp(gameObject.GetComponent<Light>().intensity, targetIntensity, fadeSpeed * Time.deltaTime);
        
        CheckTargetIntensity();
        
        //if (GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<EventMan>().ActiveAlarm == false)
           // gameObject.GetComponent<Light>().intensity = Mathf.Lerp(gameObject.GetComponent<Light>().intensity, 0f, fadeSpeed * Time.deltaTime);
    }
    public void CheckTargetIntensity()
    {
        Debug.Log("Heh");
        if(Mathf.Abs(targetIntensity - gameObject.GetComponent<Light>().intensity)< changeMargin)
        {
            if (targetIntensity == gameObject.GetComponent<Light>().intensity)
                targetIntensity = lowIntensity;
            else {
                targetIntensity = highIntensity;
            }
        }
    }

}
