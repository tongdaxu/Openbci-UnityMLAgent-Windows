using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System;

public class XuAgent : Agent
{
    [Header("Specific to Ball3D")]

    public GameObject ball;
	private float alphaValue;
	private float Hue;
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
		state.Add (alphaValue);

        return state;
    }

    // to be implemented by the developer
    public override void AgentStep(float[] act)
    {
	
        float action_h = act[0];
		alphaValue = TextReadToFloat();

		//Debug.Log (alphaValue);
			
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



            if (done == false)
            {
                reward = 0.1f;
            }
   
		if ((alphaValue - oldalphaValue) < -1)
        {
            done = true;
            reward = -1f;
        }
		oldalphaValue = alphaValue;

		rend.material.shader = Shader.Find("Specular");
		rend.material.SetColor ("_Color", Color.HSVToRGB (Hue, 1f, 1f));

    }

    // to be implemented by the developer
    public override void AgentReset()
    {
		alphaValue = TextReadToFloat ();
		Hue = Random.Range(0f,1f);
        
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
		try{
		string lines = System.IO.File.ReadAllText (@"C:\Git\ml-agents\unity-environment\Assets\ML-Agents\Alphawave\AlphaRecord.txt");
		//string[] sArray = lines.Split ('/');
		//int lineNumber = System.Text.RegularExpressions.Regex.Matches (lines, "/").Count;
		float tempFloat = float.Parse (lines);
		return tempFloat;
		}

		catch(IOException ){
		return oldalphaValue;
			Debug.Log("Read failed");

		}

	}
}
