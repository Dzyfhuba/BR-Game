using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
 public void MainMenu ()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }   
}