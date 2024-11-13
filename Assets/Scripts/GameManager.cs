using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
   private int width = 5;
   private int height = 5;

   public GameObject ground;
   public GameObject player;
   public Transform groundParent;
   
   private List<GameObject> groundList = new List<GameObject>();
   private List<int> groundNumberList = new List<int>();

   private void Start()
   {
      LoadTiles();
      Arrangement();
   }

   private void LoadTiles()
   {
      for (int i = 0; i < width * height; i++)
      {
         GameObject tiles = Instantiate(ground, Vector3.zero, Quaternion.identity);
         tiles.transform.parent = groundParent;
         groundList.Add(tiles);
         groundNumberList.Add(0);
      }
      ground.SetActive(false);
   }

   private void Arrangement()
   {
      for (int h = 0; h < height; h++)
      {
         for (int w = 0; w < width; w++)
         {
            groundList[width * h + w].transform.position = new Vector3(-(width-1) / 2f + w, -0.5f, h);
         }
      }
      player.transform.position = new Vector3(0, 0.3f, 0);
   }
}
