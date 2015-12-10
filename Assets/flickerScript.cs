using UnityEngine;
using System.Collections;

public class flickerScript : MonoBehaviour {
    public Light light;

    public float minIntensity = 1f;
     public float maxIntensity = 8f;
 
     float random;
 
     void Start()
     {
         random = Random.Range(0.0f, 65535.0f);
     }

     void Update()
     {
         float noise = Mathf.PerlinNoise(random, Time.time);
         light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
     }


}
