using UnityEngine;
using System.Collections;

public class UfoController : MonoBehaviour {
    public float MoveSpeed = 5f;
    public int Direction = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Direction * MoveSpeed * Time.deltaTime, 0f, 0f);
	}
}
