using UnityEngine;

public class SampleScript : MonoBehaviour
{
    private SpriteRenderer parentRenderer;
    private SpriteRenderer childRenderer;

    [SerializeField] public Color parentColor;
    [SerializeField] public Color childColor;

    private void Start()
    {
        parentRenderer = GetComponent<SpriteRenderer>();
        childRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        parentRenderer.color = parentColor;
        childRenderer.color = childColor;

        Debug.Log("This code is starting");
    }

    private void Awake()
    {
        Debug.Log("This code is Awake");
    }

    private void OnEnable()
    {
        //Debug.Log("This code is Enabled");
        Debug.Log("The Object Appears!");
    }

    private void OnDisable()
    {
        //Debug.Log("This code is disabled");
        Debug.Log("The Object Vanishes........");
    }

    private void Update() //per frame, speed = base high end of CPU
    {
        Debug.Log("This code is running every frame");
    }

   
    private void FixedUpdate() // Will run per fixed frame, speed = 0.02
    {
     // used for game physics
     // component rigidbody
     // component Character Controller
    }

    // High end of CPU
    private void LateUpdate() // per fraame speed = base high end of CPU, it runs after update
    {
        
    }
}
