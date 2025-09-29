using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screen position of the mouse from input
        Vector3 mousePos2d = Input.mousePosition;

        /*
        the cameras r position set show far to push the mouse into 3d
        if this line causes a nullreferenceexception, select the main camera
        in the hierarchy and st its tag to maincamera in the inspect

        */

        mousePos2d.z = -Camera.main.transform.position.z;
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
