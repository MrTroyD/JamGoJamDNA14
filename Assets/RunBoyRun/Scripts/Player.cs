using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private bool _moving;
    private float _movingTimeStart;

    float _moveSpeed = .45f;

    private float _startZ;
    private float _endZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._moving)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this._movingTimeStart = 0;
                this._moving = true;
                this._startZ = this.transform.position.z;
                this._endZ = this.transform.position.z + 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                this._movingTimeStart = 0;
                this._moving = true;
                this._startZ = this.transform.position.z;
                this._endZ = this.transform.position.z - 1;
            }
        }
        else
        {
            this._movingTimeStart += Time.deltaTime;
            if (this._movingTimeStart < this._moveSpeed) 
            {
                float timePercent = this._movingTimeStart / this._moveSpeed;
                if (timePercent > 1)
                {
                    timePercent = 1;
                } 
                float targetZ = Mathf.Lerp(this._startZ, this._endZ, timePercent);

                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, targetZ) ;
            }
            else
            {
                this._moving  = false;
            }

        }
        
    }

    public void OnSpawn()
    {
        this.enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {

        switch (other.gameObject.tag)
        {
            case "Hazard":
            case "Projectile":
                print ("DEATH");
                this._rigidBody.useGravity = false;
                this._moving = false;
                GameManager.Instance.OnPlayerDeath();

                this.enabled = false;

                if (other.gameObject.tag == "Projectile")
                {

                }
                break;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.OnHitSlick();
    }
}
