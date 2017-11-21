using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System;

public class XuAgent : Agent
{
    [Header("Specific to Ball3D")]

    
	private float alphaValue;
	private float Hue;
	private float Sat;
	private float Val;


	private float oldalphaValue;
	private float alphaTemp1;
	private float alphaTemp2;
	//Random ra = new Random();


	public void InitializeAcademy(){
    
	}

    public override List<float> CollectState()
	{
		
        List<float> state = new List<float>();

        state.Add (Hue);
		state.Add (Sat);
		state.Add (Val);
		state.Add (alphaValue/100f);

        return state;
    }

    // to be implemented by the developer
    public override void AgentStep(float[] act)
    {
		Renderer rend = GetComponent<Renderer>();


			alphaValue = TextReadToFloat ();
	

		Debug.Log (alphaValue);

					
		float action_h = act[0];

		    if (action_h/500 + Hue > 1.0f)
            {
			//Hue = 0.99f;
			done = true;
			reward = -0.2f;
			}

			if (action_h/500 +Hue < 0f)
            {
			//Hue = 0.01f;
			done = true;
			reward = -0.2f;
            }
            else
            {
			Hue = Hue + action_h/500;
            }

		float action_s = act[1];

		if (action_s/500 + Sat > 1.0f)
		{
			//Sat = 0.99f;
			done = true;
			reward = -0.2f;
		}

		if (action_s/500 +Sat < 0f)
		{
			//Sat = 0.01f;
			done = true;
			reward = -0.2f;
		}
		else
		{
			Sat = Sat + action_s/500;
		}

		float action_v = act[2];

		if (action_v/500 + Val > 1.0f)
		{
			//Val = 0.99f;
			done = true;
			reward = -0.2f;
		}

		if (action_v/500 +Val < 0f)
		{
			//Val = 0.01f;
			done = true;
			reward = -0.2f;
		}
		else
		{
			Val = Val + action_v/500;
		}


            if (done == false)
            {
                reward = 0.1f;
            }
   
		if ((alphaValue/oldalphaValue) > 1.1f )
        {
            done = true;
            reward = -1f;
        }

		oldalphaValue = alphaValue;

		rend.material.shader = Shader.Find("Specular");
		rend.material.SetColor ("_Color", Color.HSVToRGB (Hue, Sat, Val));

    }

    // to be implemented by the developer
    public override void AgentReset()
    {
		alphaValue = TextReadToFloat ();
		Hue = Random.Range(0.01f,0.99f);
		Sat = Random.Range(0.01f,0.99f);
		Val = Random.Range(0.01f,0.99f);
        
    }



	public float TextReadToFloat() {
		

		/*
		 *string fileName = "AlphaRecord.txt";
		string sourcePath = @"C:\Git\ml-agents\unity-environment\Assets\ML-Agents\Alphawave";
		string targetPath =  @"C:\Git\ml-agents\unity-environment\Assets\ML-Agents\Alphawave\dup";
		string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
		string destFile = System.IO.Path.Combine(targetPath, fileName);
		if (!System.IO.Directory.Exists(targetPath))
		{
			System.IO.Directory.CreateDirectory(targetPath);
		}


		System.IO.File.Copy(sourceFile, destFile, true);



		if (System.IO.Directory.Exists(sourcePath))
		{
			string[] files = System.IO.Directory.GetFiles(sourcePath);
			//Debug.Log ("find file");
			// Copy the files and overwrite destination files if they already exist.
			foreach (string s in files)
			{
				// Use static Path methods to extract only the file name from the path.
				fileName = System.IO.Path.GetFileName(s);
				destFile = System.IO.Path.Combine(targetPath, fileName);
				System.IO.File.Copy(s, destFile, true);
			}
		}
		else
		{
			Debug.Log("Source path does not exist!");
		}

*/
		float readvalue;


			try {
				string lines = System.IO.File.ReadAllText (@"C:\Git\ml-agents\unity-environment\Assets\ML-Agents\Alphawave\AlphaRecord.txt");
				//string[] sArray = lines.Split ('/');
				//int lineNumber = System.Text.RegularExpressions.Regex.Matches (lines, "/").Count;
				readvalue = float.Parse (lines);
			return readvalue;
		
			} catch (IOException) {
			
			Debug.Log ("Read failed");

			
			return oldalphaValue;
		
		}

	}
}
