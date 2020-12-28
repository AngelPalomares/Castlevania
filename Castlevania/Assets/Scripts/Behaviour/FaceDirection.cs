using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : AbstractBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Right = inputState.GetButtonValue(InputButtons[0]);
        var leftt = inputState.GetButtonValue(InputButtons[1]);

        if(Right)
        {
            inputState.direction = Direction.Right;
        }
        else if(leftt)
        {
            inputState.direction = Direction.Left;
        }

        transform.localScale = new Vector3((float)inputState.direction, 1, 1);

    }
}
