using AreaCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Services
{
    public class Circle : Ishape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI*radius*radius;
        }
    }
}
