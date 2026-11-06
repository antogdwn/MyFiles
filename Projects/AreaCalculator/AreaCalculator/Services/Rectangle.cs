using AreaCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Services
{
    public class Rectangle :Ishape
    {
        private double width, height;
        public Rectangle(double width,double height) { 
            this.width = width;
            this.height = height;
        }

        public double Width { get { return width; } set { width = value; } }
        public double Height { get { return height; } set { height = value; } }

        public double GetArea()
        {
            return width * height;
        }
    }
}
