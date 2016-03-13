using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teeth : MonoBehaviour {

    //How many times does the brush need to touch this tooth to be clean?
    public float numTimesToClean = 5;

    //How many times has the brush touched it so far?
    private float numTimesTouched = 0;

    //Is created when the tooth is fully cleaned.
    public GameObject finishedParticleEffect;

    //Hardcoded greenish
    public Color dirtyColor = new Color(.76f, 1.0f, 0f ,.38f);

    //Pure white.
    public Color cleanColor = new Color(1f,1f,1f);

    //True when fully cleaned.
    public bool isClean = false;

    //Meat of the code, assumed that only the brush will collide with this tooth.
    void OnTriggerEnter2D (Collider2D other) {

        //If the teeth still need to be cleaned.
        if (numTimesTouched < numTimesToClean)
        {
            numTimesTouched++;

            //Lerping between dirty and clean values based on how many touches happened.
            GetComponent<Image>().color = Color.Lerp(dirtyColor, cleanColor, numTimesTouched / numTimesToClean);

            //Last one, create particle effect and play sound.
            if (numTimesTouched == numTimesToClean)
            {
                isClean = true;

                //Getting the position and placing it above the background.
                Vector3 particlePos = this.transform.position;

                //Setting the z pos to 0 cause otherwise it's too far away from the camera.
                particlePos.z = 0;

                FinishButton.teethCleaned++;
                GameObject.Instantiate(finishedParticleEffect, particlePos, new Quaternion());
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
