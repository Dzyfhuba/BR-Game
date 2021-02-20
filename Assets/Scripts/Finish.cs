using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

[System.Serializable]

public class Finish : MonoBehaviour
{

	public GameObject Player1Time;
	public GameObject FinishPanel;
    public Collider FinishCollider;
    Text txt;
    public float timeRecord = 0;
    public float timeStart;

    void Start()
    {
    	txt = Player1Time.GetComponent<Text>();
    	timeRecord = 0;
    	timeStart = Time.time;
    }

    void Update()
    {
    	timeRecord = Time.time - timeStart;
    	
    }

  	public void OnTriggerEnter(Collider other)
  	{
  		FinishPanel.SetActive(true);
  		// txt.text = GetMinutes().ToString("n2") + ":" + GetSeconds().ToString("n2") + "." + GetMilliseconds().ToString("n2");
  		txt.text = String.Format( "{0:00}:{1:00}:{2:00}",GetMinutes(),GetSeconds(),GetMilliseconds());
  	}
    
    public void NextLevel(){
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BacKToMenu(){
    	SceneManager.LoadScene(1);
    }

    public int GetMinutes()
      {
          return (int)(timeRecord / 60f);
      }
  
      public int GetSeconds()
      {
          return (int)(timeRecord);
      }
  
      public float GetMilliseconds()
      {
          return (float)(timeRecord - System.Math.Truncate(timeRecord));
      }
 
      public float GetRawElapsedTime()
      {
          return timeRecord;
	}
}
