using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class knife : MonoBehaviour
{

    public Rigidbody rb;

    public Vector2 startswipepos;

    private Vector2 endSwipe;

    public float force = 15f;

    public float torque = 20f;

    public Collider sphere;

    public bool air = false;








    void Start()
    {
        transform.position = new Vector3(-0.67f, 4f, -3.57f);

        sphere = GetComponent<SphereCollider>();
    }


    void Update()
    {
        if (air == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startswipepos = Camera.main.ScreenToViewportPoint(Input.mousePosition);



            }

            if (Input.GetMouseButtonUp(0))
            {

                endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                Swipe();
                air = true;


            }

        }






        if (rb.velocity.y >= 1)
        {
            Invoke("lalal", 0.5f);


        }


    }




    public void lalal()
    {

        sphere.enabled = true;


    }

    public void Swipe()
    {
        sphere.enabled = false;
        rb.isKinematic = false;



        Vector2 swipe = endSwipe - startswipepos;


        rb.AddForce(swipe * force, ForceMode.Impulse);
        rb.AddTorque(torque, 0f, 0f, ForceMode.Impulse);



    }




    void OnTriggerEnter()
    {
        rb.isKinematic = true;
        air = false;




    }

    private void OnCollisionEnter(Collision collision)
    {




        if (collision.collider.gameObject.tag == "Ground")
        {

            Destroy(gameObject);
            Restart();
        }





    }

    public void Restart()
    {


        SceneManager.LoadScene("SampleScene");


    }

}
