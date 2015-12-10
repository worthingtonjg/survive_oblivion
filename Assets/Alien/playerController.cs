using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class playerController : MonoBehaviour {
    public int Life = 10;
    public Texture2D cursorTexture;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float bulletSpeed = 10f;
    public float distance = 10f;
    public Text lives;
    public GameObject flowChart;

    private int kills = 0;
    private Flowchart flowChartScript;

	// Use this for initialization
	void Start () {
        lives.text = Life.ToString();
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }

        if(flowChart != null)
        {
            flowChartScript = flowChart.GetComponent<Flowchart>();
        }
	}
	
	// Update is called once per frame
    void Update()
    {
	    // If the Button “Fire1” is pressed down it will return true and so we enter the if condition
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name.ToLower().Contains("alien"))
                {
                    var expl = Instantiate(explosionPrefab, hit.transform.position, Quaternion.identity);
                    GameObject.Destroy(hit.transform.gameObject);
                    Destroy(expl, .25f);
                    ++kills;
                }
            }

            if (kills == 10)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                flowChartScript.ExecuteBlock("YouWin");
            }
        }
    }

    public void DecrementLife()
    {
        --Life;
        lives.text = Life.ToString();
        if(flowChartScript != null)
        {
            flowChartScript.ExecuteBlock("Damage");
        }

        if (Life <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            flowChartScript.ExecuteBlock("YouLose");
        }
    }
}
