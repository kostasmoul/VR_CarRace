using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MoveCar : MonoBehaviour {
    public Transform vrCamera;
    public Canvas optionsCanvas;
    public Canvas scoreCanvas;
    public Text scoreText;
    public Text scoreTitle;
    private bool shouldMove;
    
    private int currentscore = 0;
    private ParticleSystem ps;

    // Use this for initialization
    void Start () {
        shouldMove = true;
        optionsCanvas.enabled = false;
        ps = scoreCanvas.GetComponent<ParticleSystem>();
        ps.Stop();
	}
	
	// Update is called once per frame
	void Update () {

        if (shouldMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10.5f);

            if (WrapAngle(vrCamera.eulerAngles.z) > 10.0f && WrapAngle(vrCamera.eulerAngles.z) < 48.0f && transform.position.z > -14.9f)
            {
                //move to the left
                transform.Translate(Vector3.left * Time.deltaTime * 10.5f);

            }
            if (WrapAngle(vrCamera.eulerAngles.z) < -10.0f && WrapAngle(vrCamera.eulerAngles.z) > -48.0f && transform.position.z < -5.1f) //meaning from -15(345) to -25(335) degrees rotation of the z axis
            {
                //move to the right
                transform.Translate(Vector3.right * Time.deltaTime * 10.5f);

            }
        }

    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    //when the car hits an object that makes us lose
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bad_object")
        {
            Debug.Log("hit a cube object");
            shouldMove = false;
            optionsCanvas.enabled = true;
          
            scoreText.text = "0/7";
            scoreTitle.text = "YOU LOST";
        }

        if(other.gameObject.tag == "good_object")
        {
            Debug.Log("hit a good sphere");
            scoreText.text = (currentscore + 1).ToString() + "/7";
            optionsCanvas.GetComponent<AudioSource>().Play();
            ps.Play();
            Invoke("stopParticles", 2);
         
            currentscore = currentscore + 1;
           

        }
        if(other.gameObject.tag == "end_object")
        {
            shouldMove = false;
            optionsCanvas.enabled = true;
            scoreTitle.text = "YOU WON!";
        }
       

        
    }

    private void stopParticles()
    {
        ps.Stop();
        optionsCanvas.GetComponent<AudioSource>().Stop();
    }
    

}
