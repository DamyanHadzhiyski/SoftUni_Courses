using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Encapsulation
{
    public class Box
    {
		private double length;
		private double width;
		private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
		{
			get { return length; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Length cannot be zero or negative.");
				}

                length = value;
			}
		}
		public double Width
		{
			get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }
		public double Height
		{
			get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * width * length + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * height * (width + length);  
        }

        public double Volume()
        {
            return width * length * height;
        }
	}
}
