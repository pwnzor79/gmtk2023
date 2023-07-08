using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Tooltip("Character we are following")]
    [SerializeField] private GameObject following;

    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float upperBound;
    [SerializeField] private float lowerBound;

    private float adjustedLeftBound;
    private float adjustedRightBound;


    private void Awake()
    {
        if (following == null)
        {
            Debug.LogError("You didn't assign something to follow!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (following == null)
        {
            Debug.LogError("You didn't assign something to follow!");
        }
        transform.position = following.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float boundedX = Mathf.Clamp(following.transform.position.x, leftBound, rightBound);
        float boundedY = Mathf.Clamp(following.transform.position.y, lowerBound, upperBound);
        transform.position = new Vector3(boundedX, boundedY, transform.position.z);

    }

}
