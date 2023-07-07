using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float time;
    public int health;
    public int score;

    [SerializeField]
    public PlayerController playerController;

    public FrictionArea currentFrictionArea;

    //STORE THE DEFAULT VALUES FOR PLAYER DRAG
    public float defaultDrag;
    public float defaultAngularDrag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //takes a friction area, which calls gamemanager.updatefrictionarea.this
    public void FrictionAreaEntered(FrictionArea frictionArea)
    {
        currentFrictionArea = frictionArea;
        playerController.playerRigidbody.drag = frictionArea.friction;
        playerController.playerRigidbody.angularDrag = frictionArea.angularFriction;
    }

    public void FrictionAreaExited(FrictionArea frictionArea)
    {
        Debug.Log("yo whatup");
        if (frictionArea == currentFrictionArea)
        {
            playerController.playerRigidbody.drag = defaultDrag;
            playerController.playerRigidbody.angularDrag = defaultAngularDrag;
        }
    }

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }

}
