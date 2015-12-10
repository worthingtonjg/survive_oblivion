using UnityEngine;
using System.Collections;

public class MissleController : MonoBehaviour {
    public float MoveSpeed = 5f;
    public GameObject explosionPrefab;
    
    private GameObject invasionController;
    private InvasionController invasionControllerScript;
	// Use this for initialization
	void Start () {
        invasionController = GameObject.Find("_InvasionController");
	    if(invasionController != null)
        {
            invasionControllerScript = invasionController.GetComponent<InvasionController>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, MoveSpeed * Time.deltaTime, 0f);

        if (transform.position.y >= 25)
        {
            GameObject.Destroy(transform.gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        var expl = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);

        GameObject.Destroy(other.gameObject);
        GameObject.Destroy(transform.gameObject);

        invasionControllerScript.Spawn();
        invasionControllerScript.IncrementScore();
                
        Destroy(expl, .25f);
    }
}
