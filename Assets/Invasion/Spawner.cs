using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public int Direction = 1;
    public GameObject InvasionController;

    private InvasionController invasionControllerScript;

	// Use this for initialization
	void Start () {
        invasionControllerScript = InvasionController.GetComponent<InvasionController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<UfoController>().Direction != Direction)
        {
            invasionControllerScript.Spawn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UfoController>().Direction != Direction)
        {
            GameObject.Destroy(other.gameObject);
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        float y = Random.Range(this.transform.position.y - 5, this.transform.position.y + 3);
        Debug.Log(y);
        GameObject clone = Instantiate(
            prefab, 
            new Vector3(
                this.transform.position.x, 
                y, 
                1f)
            , Quaternion.identity) as GameObject;
        clone.GetComponent<UfoController>().Direction = Direction;
        return clone;
    }
}
