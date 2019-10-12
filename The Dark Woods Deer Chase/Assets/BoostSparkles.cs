using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSparkles : MonoBehaviour
{
    public ParticleSystem boost_sparkles;
   
    // Start is called before the first frame update
    void Start()
    {

        


    }
    // Update is called once per frame
    void Update()
    {
     
    }

    public void PlaySparkles()
    {
        boost_sparkles.Emit(1);
    }

   
}
