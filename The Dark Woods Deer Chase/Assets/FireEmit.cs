using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEmit : MonoBehaviour
{
    public ParticleSystem fire;

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
        fire.Emit(1);
    }


}

