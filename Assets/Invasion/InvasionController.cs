using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class InvasionController : MonoBehaviour {
    public GameObject UfoPrefab;
    public GameObject LeftSpawner;
    public GameObject RightSpawner;
    public Texture2D cursorTexture;
    public GameObject MisslePrefab;
    public Text ScoreText;
    public Text AmmoText;
    public bool Started;
    public GameObject flowChart;
    
    private int Score;
    private int Ammo;
    private Spawner leftSpawnerScript;
    private Spawner rightSpawnerScript;
    private Flowchart flowchartScript;

    // Use this for initialization
	void Start () {
        Score = 0;
        Ammo = 120;
        AmmoText.text = Ammo.ToString();
        leftSpawnerScript = LeftSpawner.GetComponent<Spawner>();
        rightSpawnerScript = RightSpawner.GetComponent<Spawner>();

        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }

        if (flowChart != null)
        {
            flowchartScript = flowChart.GetComponent<Flowchart>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!Started) return;

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(MisslePrefab, new Vector3(p.x, -5f, -2f), Quaternion.identity);
            DecrementAmmo();
        }
	}

    public void StartGame()
    {
        // Start the first UFO
        leftSpawnerScript.Spawn(UfoPrefab);
        Started = true;
    }

    public void StopGame()
    {
        Started = false;
    }

    public void Spawn()
    {
        if (!Started) return; 

        int side = Random.Range(0, 2);

        if (side == 0)
        {
            leftSpawnerScript.Spawn(UfoPrefab);
        }
        else
        {
            rightSpawnerScript.Spawn(UfoPrefab);
        }
    }

    public void IncrementScore()
    {
        ++Score;

        ScoreText.text = Score.ToString();

        if (Score == 100)
        {
            StopGame();
            flowchartScript.ExecuteBlock("YouWin");
        }
    }

    public void DecrementAmmo()
    {
        --Ammo;
        AmmoText.text = Ammo.ToString();

        if (Ammo == 0 && Score < 100)
        {
            StopGame();
            flowchartScript.ExecuteBlock("YouLose");
        }
    }
}
