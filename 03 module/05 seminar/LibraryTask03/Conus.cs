namespace LibraryTask03
{
    public class Conus
    {
        Circle conBase; // окружность - основание конуса
        Point top; // точка - вершина конуса
        public Conus(double x, double y, double z,
                     double radius, double height)
        {
            top = new Point(x, y, z + height);
            conBase = new Circle(x, y, z, radius);
        }
        // переопределение метода ToString() для Conus
        public override string ToString()
        {
            string res = string.Format("[Конус\n\t основание " +
                "{0}\n\t вершина {1}]", conBase.ToString(), top.ToString());
           return res;
        }
        // метод вычисления площади сечения
        public double CrossSection()
        {
            return conBase.Rad * (top.Z - conBase.Center.Z);
        }
    }

}
