﻿using AiWorkbench.Client;
using AiWorkbench.Client.Events;
using AiWorkbench.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenario.Tanks
{
    public class TankManager : EntityManager<Tank>
    {
        protected override void PostUpdate(Tank current, IEnumerable<Entity> entities, Frame frame)
        {
            foreach(var tank in entities.OfType<Tank>())
            {
                // Handle movement
                if (tank.NextMovement == Tank.Movement.Forward)
                {
                    double newX = (tank.MovementSpeed * Math.Cos(tank.Heading.Radians - Math.PI / 2)) + tank.X;
                    double newY = (tank.MovementSpeed * Math.Sin(tank.Heading.Radians - Math.PI / 2)) + tank.Y;

                    tank.Position = new Position(newX, newY);
                }
                else if (tank.NextMovement == Tank.Movement.Backward)
                {
                    double newX = (tank.MovementSpeed * Math.Cos(tank.Heading.Radians - Math.PI / 2)) + tank.X;
                    double newY = (tank.MovementSpeed * Math.Sin(tank.Heading.Radians - Math.PI / 2)) + tank.Y;

                    tank.Position = new Position(newX, newY);
                }
                else if (tank.NextMovement == Tank.Movement.TurnLeft)
                    tank.Heading -= AngleHelpers.DegreesToRadians(tank.SpinSpeedDegrees);
                
                tank.PrepareForNextFrame();

                if (tank.Health <= 0)
                    frame.RaiseEvent(new RemoveEntityEvent(tank.Id));
            }
        }
    }
}
