using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunktionTimer : MonoBehaviour
{
    private static List<FunktionTimer> activeTimerListe;
    private static GameObject initGameobject;
    private static void InitIfNeeded()
    {
        if (initGameobject == null)
        {
            initGameobject = new GameObject("FunktionTimer_InitGameObject");
            activeTimerListe = new List<FunktionTimer>();
        }
    }
    public static FunktionTimer Create(Action action,float timer,string timerName = null)
    {
        InitIfNeeded();
        GameObject gameObject = new GameObject("FunktionTimer", typeof(MonoBehaviourHook));
        FunktionTimer funktionTimer = new FunktionTimer(action, timer,timerName,gameObject);
      
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = funktionTimer.Update;

        activeTimerListe.Add(funktionTimer);
        return funktionTimer;
    }
  public static void StopTimer(string timerName)
    {
        for(int i = 0; i < activeTimerListe.Count; i++)
        {
            if(activeTimerListe[i].timerName == timerName)
            {
                //stop the timer
                activeTimerListe[i].DestroySelf();
                i--;
            }
        }
    }
    private static void RemoveTimer(FunktionTimer funktionTimer)
    {
        InitIfNeeded();
        activeTimerListe.Remove(funktionTimer);
    }
    public class MonoBehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
         if(onUpdate!=null)onUpdate();

        }
    }

    private Action action;
    private float timer;
    private bool isDestroyed;
    private GameObject gameObject1;
    private string timerName;
    public FunktionTimer(Action action, float timer,string timerName,GameObject gameObject1)
    {
        this.action = action;
        this.timer = timer;
        this.gameObject1 = gameObject1;
        this.timerName = timerName;
        isDestroyed = false;
    }


    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                action();
                DestroySelf();
            }
        }    
    }
    private void DestroySelf()
    {
        isDestroyed = true;
       UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }
    

}
