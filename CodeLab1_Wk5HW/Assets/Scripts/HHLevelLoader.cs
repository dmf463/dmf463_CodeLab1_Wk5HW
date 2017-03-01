using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class HHLevelLoader : MonoBehaviour {

    public string[] fileNames;
    public static int levelNum = 0;

    // Use this for initialization
    void Start () {

        string fileName = fileNames[levelNum];
        string filePath = Application.dataPath + "/" + fileName;

        StreamReader sr = new StreamReader(filePath);
        GameObject levelHolder = new GameObject("Level Holder");

        int yPos = 0;
        GameObject player = Instantiate(Resources.Load("Prefabs/PlayerCharacter") as GameObject);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            for (int xPos = 0; xPos < line.Length; xPos++)
            {
                if (line[xPos] == 'b')
                {
                    GameObject backGround = Instantiate(Resources.Load("Prefabs/ForestBeginning") as GameObject);
                    backGround.transform.parent = levelHolder.transform;
                    backGround.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }
                if (line[xPos] == 'x')
                {
                    GameObject midGround = Instantiate(Resources.Load("Prefabs/ForestMiddle") as GameObject);
                    midGround.transform.parent = levelHolder.transform;
                    midGround.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }
                if (line[xPos] == 'e')
                {
                    GameObject midGround = Instantiate(Resources.Load("Prefabs/ForestMiddle") as GameObject);
                    midGround.transform.parent = levelHolder.transform;
                    midGround.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }
                if (line[xPos] == 'R')
                {
                    GameObject rock = Instantiate(Resources.Load("Prefabs/Rock") as GameObject);
                    rock.transform.parent = levelHolder.transform;
                    rock.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }
                if (line[xPos] == 'H')
                {
                    GameObject Enemy = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
                    Enemy.transform.parent = levelHolder.transform;
                    Enemy.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }
                if (line[xPos] == 'P')
                { // we see a 'P'
                  //Move the player to that location
                    player.transform.position = new Vector3(
                        xPos,
                        yPos,
                        0);
                }

            }

            yPos--;

        }

        sr.Close();

    }
	
	// Update is called once per frame
	void Update () {

        //If someone presses the "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Increase the level by 1
            levelNum++;
            //Reload the scene "Week5", but a new level will appear
            //because we increased the level number
            SceneManager.LoadScene("hunterHorror");
        }

    }
}
