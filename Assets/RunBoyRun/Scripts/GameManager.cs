using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


    [SerializeField]
    private RunManager _runManager;

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
        
    }

    public void ClearGame()
    {
        this._runManager.ClearGame();
    }

    public void StartGame()
    {
        this._runManager.ClearGame();
        this._runManager.BuildGame();
        this._runManager.ResumeGame();
    }
}
