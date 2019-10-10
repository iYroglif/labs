using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    abstract class GeomFigure /*: IComparable*/
    {
        string _shape;
        double _area;

        public string Shape
        {
            get { return _shape; }
            protected set { _shape = value; }
        }

        public double Area
        {
            get { return _area; }
            protected set { _area = value; }
        }

        public abstract double CalcArea();

        /*public int CompareTo(object o)
        {
            GeomFigure a = (GeomFigure)o;
            if (_area < a._area) return -1;
            else if (_area == a._area) return 0;
            else return 1;
        }*/

        public virtual string ToString() { return _shape + " плошадью " + _area.ToString(); }
    }

    interface IPrint { void Print(); }

    class Rectangle : GeomFigure, IPrint
    {
        double _height = 0;
        double _weight = 0;

        Rectangle() { Shape = "Прямоугольник"; }

        public override double CalcArea() { return _height * _weight; }

        public double Height
        {
            get { return _height; }
            private set
            {
                if (value < 0) { throw new Exception /*Console.WriteLine*/("Высота не может быть отрицателной"); }
                else { _height = value; }
            }
        }

        public double Weight
        {
            get { return _weight; }
            private set
            {
                if (value < 0) { throw new Exception /*Console.WriteLine*/("Ширина не может быть отрицателной"); }
                else { _weight = value; }
            }
        }

        public Rectangle(double h, double w) : this()
        {
            Height = h;
            Weight = w;
            Area = CalcArea();
        }

        public override string ToString() { return base.ToString() + ", высотой " + _height + " и шириной " + _weight; }

        public void Print() { Console.WriteLine(ToString()); }
    }

    class Square : Rectangle
    {
        public Square(double leng) : base(leng, leng) { Shape = "Квадрат"; }

        public override string ToString() { return base.ToString() + " и стороной " + Height; } //Как обратиться к самому родительскому классу?
    }

    class Circle : GeomFigure, IPrint
    {
        double _radius = 0;

        Circle() { Shape = "Окружность"; }

        public override double CalcArea() { return Math.PI * _radius * _radius; }

        public double Radius
        {
            get { return _radius; }
            private set
            {
                if (value < 0) { throw new Exception/*Console.WriteLine*/("Радиус не может быть отрицателной"); }
                else { _radius = value; }
            }
        }

        public Circle(double r) : this()
        {
            Radius = r;
            Area = CalcArea();
        }

        public override string ToString() { return base.ToString() + " и радиусом " + _radius; }

        public void Print() { Console.WriteLine(ToString()); }
    }

}