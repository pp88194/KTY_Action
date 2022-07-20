using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public interface ISTATe
    {
        void OnEnter(Monster monster);
        void Update();
        void OnExit();
    }

