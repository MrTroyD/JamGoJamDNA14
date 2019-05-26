using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{

    public GameObject[] ground;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Rigidbody _playerCharacter;

    private GameObject _lastChunk;

    private List<GameObject> _chunkList;
    
    private bool _running;

    private float _section;


    [SerializeField] private float _speed = 1;

    private float _acceleration = .01f;

    int _lastLane;

    public bool running
    {
        get {return this._running;}
    }

    void Start()
    {
        
        this._chunkList = new List<GameObject>();        
    }

    void Update()
    {
        if (this._running)
        {

            if (Mathf.Abs(this._player.transform.position.x) > this._section - 20) AddChunk();

        //    print (this._player.transform.position.x +","+ this._section);
            this._speed += _acceleration;

            if (this._speed < 1f) this._speed = 1f;
            if (this._speed > 12f) this._speed = 12f;

            GameManager.Instance.score += (int)this._speed;

        }
        
    }

    void FixedUpdate()
    {
        if (this._running) 
            this._player.transform.position += Vector3.right * (Time.deltaTime * this._speed);
    }

    public void ClearGame()
    {
        this._player.transform.position = Vector3.zero;
        this._playerCharacter.transform.position = new Vector3(0.05f, 1, 0);
        this._playerCharacter.velocity = Vector3.zero;
        this._playerCharacter.useGravity = false;
        this._section = 0;
        this._speed = 1;

        for (int i = 0; i < this._chunkList.Count; i++)
        {
            Destroy(this._chunkList[i]);
        }

        this._chunkList = new List<GameObject>();
    }

    public void OnHitSlick()
    {
        this._speed *= .5f;
    }

    public void BuildGame()
    {
      this._lastChunk = Instantiate(ground[0], new Vector3(), Quaternion.identity,  this.transform);
      this._chunkList.Add(this._lastChunk);
      AddChunk();
    }

    public void ResumeGame()
    {
        this._running = true;
        this._playerCharacter.useGravity = true;
    }

    public void StopGame()
    {
        this._running = false;
        this._playerCharacter.useGravity = false;
    }

    public void AddChunk()
    {
        int chunkZ = (int)this._lastChunk.transform.position.z;

        int newChunkPosition = (Random.Range(0, 3) - 1);
        if (chunkZ + newChunkPosition < -2 || chunkZ +newChunkPosition > 2) newChunkPosition = 0; 

      this._lastChunk = Instantiate(ground[Random.Range(1, ground.Length)], this._lastChunk.transform.position + (new Vector3(20, 0, newChunkPosition)), Quaternion.identity, this.transform);
      this._section += 20;

      this._chunkList.Add(this._lastChunk);

        if (this._chunkList.Count > 3)
        {
            Destroy(this._chunkList[0]);
            this._chunkList.RemoveAt(0);
        }
    }
}
