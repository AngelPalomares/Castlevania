using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehaviour
{
    public float speed = 50f;
    public float runMultiploier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Right = inputState.GetButtonValue(InputButtons[0]);
        var left = inputState.GetButtonValue(InputButtons[1]);
        var Run = inputState.GetButtonValue(InputButtons[2]);

        if (Right || left)
        {
            var tmpSpeed = speed;

            if(Run && runMultiploier > 0)
            {
                tmpSpeed *= runMultiploier;
            }


            var velX = tmpSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
    }
}
