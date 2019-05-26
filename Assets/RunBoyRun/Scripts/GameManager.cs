using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int score = 0;
    public int highScore = 10000;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private RunManager _runManager;

    [SerializeField]
    private UIManager _uiManager;

    public bool running
    {
        get {return this._runManager.running;}
    }

    public UIManager UIManager{
        get {return this._uiManager;}
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        GameManager.Instance = this;
        
        
    }
        

    // Update is called once per frame
    void Update()
    {
        if (this.highScore < this.score) this.highScore = this.score;
    }

    public void ClearGame()
    {
        this._runManager.ClearGame();
        this.score = 0;
    }

    public void StartGame()
    {
        this.score = 0;
        this._player.enabled = true;
        this._runManager.ClearGame();
        this._runManager.BuildGame();
        this._runManager.ResumeGame();
    }

    public void OnPlayerDeath()
    {
        if (!this._runManager.running) return;

        this._runManager.StopGame();
        this._uiManager.EndGame();
    }

    public void OnHitSlick()
    {
        this._runManager.OnHitSlick();
    }

    public void EndGame()
    {
        this._runManager.StopGame();
    }
}
