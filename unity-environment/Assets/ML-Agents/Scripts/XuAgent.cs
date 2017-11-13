using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuAgent : Agent
{
    [Header("Specific to Ball3D")]

    public GameObject ball;
	private float Hue = 0f;

	public void InitializeAcademy(){
	
			
	}

    public override List<float> CollectState()


    {
		
        List<float> state = new List<float>();

        state.Add (ball.transform.position.y/ 10f);
        state.Add (Hue);

        return state;
    }

    // to be implemented by the developer
    public override void AgentStep(float[] act)
    {
	
            float action_h = act[0];
		Renderer rend = GetComponent<Renderer>();

            if (action_h + Hue > 1.0f)
            {
			Hue = 1.0f;
			}

			if (action_h +Hue < 0f)
            {
			Hue = 0f;
            }
            else
            {
			Hue = Hue + action_h;
            }

		rend.material.shader = Shader.Find("Specular");
		rend.material.SetColor ("_Color", Color.HSVToRGB (Hue, 1f, 1f));



            if (done == false)
            {
                reward = 0.1f;
            }
   
		if ((ball.transform.position.y - gameObject.transform.position.y) < 1.5f)
        {
            done = true;
            reward = -1f;
        }

    }

    // to be implemented by the developer
    public override void AgentReset()
    {
		Hue = 0;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        ball.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), 4f, Random.Range(-1.5f, 1.5f)) + gameObject.transform.position;
    }
}
