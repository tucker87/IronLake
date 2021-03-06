﻿namespace IronLake
{
    public abstract class Component
    {
        public Element GameObject { get; set; }

        public Transform Transform => GameObject.Transform;

        public virtual void Activate()
        {
        }
    }
}