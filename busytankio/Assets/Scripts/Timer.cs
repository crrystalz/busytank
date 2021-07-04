using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static Timer _instance;
    public static Timer getTimer()
    {
        if(_instance != null)
        {
            return _instance;
        }
        return _instance = GameObject.FindObjectOfType<Timer>();
    }
    public class ScheduledTask
    {
        public Action whatToDo;
        public long whenToDoIt;
        public ScheduledTask(long when, Action what)
        {
            whatToDo = what;
            whenToDoIt = when;
        }
    }
    List<ScheduledTask> tasks = new List<ScheduledTask>();

    void AddTask(ScheduledTask task)
    {
        tasks.Add(task);
    }
    public void addTask(long delay, Action action)
    {
        AddTask(new ScheduledTask(Environment.TickCount + delay, action));
    }
    public void Test()
    {
        Debug.Log("Hello World");
    }
    // Start is called before the first frame update
    void Start()
    {
        AddTask(new ScheduledTask(Environment.TickCount + 5000, Test));
        addTask(6000, () =>
        {
            Debug.Log("Wow.");
        });
        Action a = () =>
        {
            Debug.Log("Very Pog");
        };
        addTask(3000, a);
    }

    // Update is called once per frame
    void Update()
    {
        List<ScheduledTask> toDoRn = new List<ScheduledTask>();
        for(int i = 0; i< tasks.Count; i++)
        {
            ScheduledTask t = tasks[i];
            if(t.whenToDoIt <= System.Environment.TickCount)
            {
                toDoRn.Add(t);
                tasks.RemoveAt(i);
                i--;
            }
        }
        for(int i = 0; i < toDoRn.Count; i++)
        {
            toDoRn[i].whatToDo();
        }

    }

}
// 000
// 001
// 010
// 011
// 100
// 101
// 110
// 111