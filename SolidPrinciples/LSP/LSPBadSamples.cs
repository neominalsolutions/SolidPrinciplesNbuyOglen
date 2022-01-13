using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LSP
{
    public class LSPBadSamples
    {
        // Liskova göre bir base sınıfın tüm memberları üyeleri inherit sınıflar (kalıtım alan) sınıflar tarafından kullanılmalıdır.// dummy method property üye olmamalıdır.

        // üst seviye sınıftan (base) türeyen alt sınıflar (inherit) sınıf başka bir sınıf yerine kullanıdığında kodda bir değişiklik olmamalıdır. (Nenseler birbileri yerine kullanılabilir)

        public abstract class BadShapeBase
        {
            public abstract double Height { get; set; }
            public abstract double Width { get; set; }
        }

        public class BadLine : BadShapeBase
        {
            public override double Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override double Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

        public class BadTriangle : BadShapeBase
        {
            public override double Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override double Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public double GetPerimeter(double firstCornerLength, double secondCornerLength, double thirthCornerLength)
            {
                return firstCornerLength + secondCornerLength + thirthCornerLength;
            }
        }

        public class BadSquare : BadShapeBase
        {
            // yükseklik ve genişilik aynı olacAK

            public override double Height { get; set; }
            public override double Width { get; set; }


            public double GetPerimeter()
            {
                if (this.Height != this.Width)
                    throw new Exception("Kare olamaz");

                return 4 * this.Height;
            }


        }

    }
}
