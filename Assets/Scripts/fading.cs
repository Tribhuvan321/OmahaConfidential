using System.Collections;
using UnityEngine;

public class Fading : MonoBehaviour
{
    public CanvasGroup fade;
    public bool faded = false;
    public GameObject destination;
    public GameObject XRSetup;

    void Start()
    {
        fade.alpha = 0f; // Start with fully transparent
    }

    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            fade.gameObject.SetActive(true);
            StartCoroutine(Fadein());
            Debug.Log("Trigger is working");
            

            
        }
        
    }

    IEnumerator Fadein()
    {
        float targetAlpha = 1f;

        float speed = 1f; // Adjust this to control the fading speed

        while (fade.alpha != targetAlpha)
        {
            fade.alpha = Mathf.MoveTowards(fade.alpha, targetAlpha, Time.deltaTime * speed);
            yield return null;
        }

        // Toggle faded state
        faded = !faded;
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        float targetAlpha = 0f;

        float speed = 1f; // Adjust this to control the fading speed
        
        //gameObject.transform.rotation = destination.transform.rotation;
        while (fade.alpha != targetAlpha)
        {
            fade.alpha = Mathf.MoveTowards(fade.alpha, targetAlpha, Time.deltaTime * speed);
            if(fade.alpha > 0.5f)
            {
                XRSetup.transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
                gameObject.transform.position = destination.transform.position;
                
               
            }
            fade.gameObject.SetActive(false);
            yield return null;
        }
      
        // Toggle faded state
        faded = !faded;
    }
}
