using UnityEngine;
using System.Collections;

public class alienScript : MonoBehaviour {
    public float shootFrequency = 3f;
    public GameObject playerController;

    
    private Animator animator;
    private playerController playerControllerScript;
    private bool isUp;
	// Use this for initialization
	void Start () {
        InvokeRepeating("takeAction", Random.Range(2,5), shootFrequency);

        animator = this.GetComponent<Animator>();

        playerControllerScript = playerController.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void takeAction()
    {
        if (playerControllerScript.Life <= 0) return;

        if (transform.position.y > 0)
            playerControllerScript.DecrementLife();

        if (isUp)
        {
            int action = Random.Range(0, 2);
            if (action == 1)
            {
                animator.SetTrigger("shoot");
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x-10f, this.transform.position.y, this.transform.position.z);
                isUp = false;
            }
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x+10f, this.transform.position.y, this.transform.position.z);
            isUp = true;
        }

    }
}
