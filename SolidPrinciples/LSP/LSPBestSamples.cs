using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LSP
{
    public class LSPBestSamples
    {

        public abstract class TwoDimensionShapeBase
        {
           


            // buradaki methodların nasıl bir logice sahip olcağını bilmiyoruz.
            public abstract double GetPerimeter();
            public abstract double GetArea();

            


        }

        public abstract class Dimension3ShapeBase:TwoDimensionShapeBase
        {
            private double _depth;

            protected Dimension3ShapeBase(double depth) 
            {
                _depth = depth;
            }

            // nasıl hesaplanacağı hakkında bir fikrimiz yok
            public abstract double GetVolume();
        }

        public class Cube : Dimension3ShapeBase
        {
            public Cube(double depth) : base(depth)
            {
            }

            public override double GetArea()
            {
                throw new NotImplementedException();
            }

            public override double GetPerimeter()
            {
                throw new NotImplementedException();
            }

            public override double GetVolume()
            {
                throw new NotImplementedException();
            }
        }

        public class Square : TwoDimensionShapeBase
        {
            public int Length { get; set; }



            public override double GetArea()
            {
                return Length * Length;
            }

            public override double GetPerimeter()
            {
                return 4 * Length;
            }
        }

        public class Circle : TwoDimensionShapeBase
        {
            public int Radius { get; set; }

            public override double GetArea()
            {
                throw new NotImplementedException();
            }

            public override double GetPerimeter()
            {
                throw new NotImplementedException();
            }
        }

        public class Rectangle: TwoDimensionShapeBase
        {
            public int Height { get; set; }
            public int Width { get; set; }

            public override double GetArea()
            {
                throw new NotImplementedException();
            }

            public override double GetPerimeter()
            {
                throw new NotImplementedException();
            }
        }

        public class Triangle : TwoDimensionShapeBase
        {
            public int Height { get; set; }

            public double LongestCornerLength { get; set; }
            public double OtherCornerLength { get; set; }
            public double SubCornerLength { get; set; }

            public override double GetArea()
            {
                return (SubCornerLength * Height) / 2;
            }

            public override double GetPerimeter()
            {
                return LongestCornerLength + OtherCornerLength + SubCornerLength;
            }
        }

    }
}
