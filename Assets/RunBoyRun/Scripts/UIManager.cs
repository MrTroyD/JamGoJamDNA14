using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] 
    GameObject _titleScreen;

    [SerializeField]
    GameObject _gameOverScreen;

    [SerializeField]
    TMP_Text _scoreValue;

    [SerializeField]
    TMP_Text _highScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        this._titleScreen.SetActive(true);
        this._gameOverScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.running)
        {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        this._scoreValue.text = GameManager.Instance.score.ToString() +"00";
        this._highScoreValue.text = GameManager.Instance.highScore.ToString() +"00";
    }

    public void StartGame()
    {
        this._titleScreen.SetActive(false);
        this._gameOverScreen.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void ResetGame()
    {
        GameManager.Instance.ClearGame();
    }

    public void ShowScreen()
    {
        this._titleScreen.SetActive(true);
    }

    public void EndGame()
    {
        this._gameOverScreen.SetActive(true);
        this._gameOverScreen.GetComponent<Animator>().Play("TransitionIn");
 
        UpdateUI();

    }
}
