using FlaxEngine;
using System;

namespace Game
{
    public class MoveToTarget : Script
    {
        public double TargetRadius { get; set; } = 0;
        public double TargetAngle { get; set; } = 0;

        public double CurrentRadius { get; set; } = 0;
        public double CurrentAngle { get; set; } = 0;

        public override void OnFixedUpdate()
        {
            CurrentRadius += (TargetRadius - CurrentRadius) * 0.05;
            CurrentAngle += (TargetAngle - CurrentAngle) * 0.05;

            UpdatePosition();
        }

        public void UpdatePosition()
        {
            Actor.Position = new Vector3(
                CurrentRadius * (float)Math.Cos(CurrentAngle),
                0,
                CurrentRadius * (float)Math.Sin(CurrentAngle));
        }
    }
}
