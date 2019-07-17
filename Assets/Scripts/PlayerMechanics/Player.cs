using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    ///GameObject c_bolt;

    public Transform target;

    [SerializeField]
    [Range(200,1000)]
    int r_speed = 200;
    [SerializeField]
    Transform P1;
    [SerializeField]
    Transform P2;
    [SerializeField]
    int force = 1000;

    bool attached;

    Vector3 side;
    bool p2;

    public GameObject c_bolt;

    Rigidbody2D rb;
    
    [SerializeField]
    private GameObject audioManagerObject;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        ///c_bolt = GameObject.FindGameObjectWithTag("Start");
        rb = GetComponent<Rigidbody2D>();
        
        ///audioManager = audioManagerObject.GetComponent<AudioManager>();
        
        Set_Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.RotateAround(target.position, target.forward, r_speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && attached)
        {
            Jump();
            print("Pressed");
        }

        if (p2)
            Debug.DrawRay(transform.position, -transform.up * 10);
        else
            Debug.DrawRay(transform.position, transform.up * 10);
    }



    void Set_Pos(Transform tgt)
    {

        transform.position = tgt.position;
        transform.position += side;


        var direction = (tgt.transform.position - transform.position).normalized;
        if (p2)
            transform.up = direction;
        else
            transform.up = -direction;

    }


    void Jump()
    {
        attached = false;
        target = transform;
        rb.simulated = true;

        rb.velocity = new Vector2(0,0);
        if (p2)
            rb.AddForce((-transform.up) * force);
        else
            rb.AddForce((transform.up) * force);
            
        string fileToPlay = "ClipOut";
        fileToPlay += Random.Range(1, 8).ToString();
        fileToPlay += ".wav";
        ///audioManager.Play(fileToPlay, false);

        r_speed += 200;
        
    }

    void Set_Start()
    {
        p2 = true;
        rb.simulated = false;
        target = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        side = P2.localPosition;
        Set_Pos(target);
        attached = true;
    }

    public void Attach_Bolt(Transform p_side, bool c_side, Transform tgt)
    {
        rb.simulated = false;
        target = tgt;
        attached = true;
        side = p_side.localPosition;
        p2 = c_side;
        Set_Pos(target);
        
        string fileToPlay = "ClipIn";
        fileToPlay += Random.Range(1, 6).ToString();
        fileToPlay += ".wav";
        ///audioManager.Play(fileToPlay, false);

        r_speed -= 200;
    }

}
