using System;

delegate int NumberChanger(int n);
namespace netCoreStudy.Feature{
    class TesDele
    {
        static int num = 10;
        public static int Addnum(int p)
        {
            num += p;
            return num;
        }

        public static int Multnum(int p)
        {
            num *= p;
            return num;
        }
        public static int GetNum() => num;

        public static void test()
        {
            NumberChanger nc1 = new NumberChanger(Addnum);
            NumberChanger nc2 = new NumberChanger(Multnum);
            nc1(25);
            System.Console.WriteLine(GetNum());
        }
    }
}