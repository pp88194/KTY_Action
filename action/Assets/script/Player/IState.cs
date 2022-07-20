using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public interface Istate
    {
        void OnEnter(Player Player);
        void Update();
        void OnExit();
    }

