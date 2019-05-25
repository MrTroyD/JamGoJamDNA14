using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{

    public GameObject[] ground;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _playerCharacter;

    private GameObject _lastChunk;
    
    private bool _running;

    [SerializeField] private float _speed = 1;

    public bool running
    {
        get {return this._running;}
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (this._running)
        {
            this._player.transform.position += Vector3.right * (Time.deltaTime * this._speed);
        }
        
    }

    public void ClearGame()
    {
        this._player.transform.position = Vector3.zero;
        this._playerCharacter.transform.position = Vector3.up;
    }

    public void BuildGame()
    {
      this._lastChunk = Instantiate(ground[0], new Vector3(), Quaternion.identity,  this.transform);
      
      AddChunk();
    }

    public void ResumeGame()
    {
        this._running = true;
    }

    public void StopGame()
    {
        this._running = false;
    }

    public void AddChunk()
    {
      this._lastChunk = Instantiate(ground[Random.Range(0, ground.Length)], this._lastChunk.transform.position + (new Vector3(20, 0, 0)), Quaternion.identity, this.transform);
    }
}
