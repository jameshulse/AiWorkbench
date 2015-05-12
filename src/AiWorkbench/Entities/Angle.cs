﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiWorkbench.Entities
{
    public struct Angle
    {
        public double Degrees { get { return RadianToDegree(Radians); } }
        public double Radians { get; private set; }

        private Angle(double radians)
        {
            Radians = radians;
        }

        public static Angle FromRadians(double angle)
        {
            return new Angle(angle % (Math.PI * 2));
        }

        public static Angle FromDegrees(double angle)
        {
            return new Angle(DegreesToRadians(angle % 360));
        }

        private static double DegreesToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private static double RadianToDegree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        public static Angle operator +(Angle instance, double radians)
        {
            return new Angle(instance.Radians + radians);
        }

        public static Angle operator -(Angle instance, double radians)
        {
            return new Angle(instance.Radians - radians);
        }

        public static bool operator ==(Angle a, Angle b)
        {
            return a.Degrees == b.Degrees;
        }

        public static bool operator !=(Angle a, Angle b)
        {
            return a.Degrees != b.Degrees;
        }
    }
}
