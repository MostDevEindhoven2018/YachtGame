﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Hybrid.Components
{
    public class Jump : MonoBehaviour
    {
        public float MaxJumpHeigth;
        public float IntendedJumpHeigth;
        public bool AllowAdditionalHeigth = true;
    }
}