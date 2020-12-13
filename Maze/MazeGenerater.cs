using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Maze
{
    class MazeGenerater
    {
        Dictionary<Point, List<Point>> dict = new Dictionary<Point, List<Point>>();
        bool[,] marked;
        int size = 0;
        public MazeGenerater(int size)
        {
            this.size = size;
            marked = new bool[size+2, size+2];
            Point p0 = new Point(1, 1);
            for (int i = 0; i < size; i++)
            {
                marked[0, i] = true;
                marked[i, 0] = true;
                marked[size+1, i] = true;
                marked[i, size+1] = true;
            }
            Addp(p0);
        }

        private void Addp(Point stp)
        {
            Random ran = new Random();
            List<Point> l1 = new List<Point>();
            l1.Add(ramP(stp,0,rs: ran.Next(1, 100000)));
            marked[stp.X, stp.Y] = false;
            l1.Add(ramP(stp,0, rs: ran.Next(1, 100000)));
            dict.Add(stp,l1);
            Addp(l1[0]);Addp(l1[1]);
            return;
        }

        private Point ramP(Point stp,int d=0,int rs=1235)
        {
            Random ran = new Random();
            int r = ran.Next(1, 100000);
            Point newp = stp;
            int direction = (d+ ran.Next(0, 3)) % 4+1;
            int range = ran.Next(1, 5);
            bool valid = true;
            //System.Windows.MessageBox.Show(d.ToString());
            switch (direction)
            {
                case 1:
                    for(int i=stp.X;i<= stp.X + range&&valid; i++)
                    {
                        if (stp.X + range > size - 2) valid = false;
                        if (marked[i, stp.Y] == true) valid = false;
                    }
                    if (valid)
                    {
                        newp.X += range;
                    }
                    else
                    {
                        newp = ramP(stp, direction + 1,rs);
                    }
                    break;
                case 2:
                    for (int i = stp.Y; i <= stp.Y + range && valid; i++)
                    {
                        if (stp.Y + range > size - 2) valid = false;
                        if (marked[stp.X, i] == true) valid = false;
                    }
                    if (valid)
                    {
                        newp.Y += range;
                    }
                    else
                    {
                        newp = ramP(stp, direction + 1, rs);
                    }
                    break;
                case 3:
                    for (int i = stp.X; i >= stp.X - range && valid; i--)
                    {
                        if (stp.X - range < 1) valid = false;
                        if (marked[i, stp.Y] == true) valid = false;
                    }
                    if (valid)
                    {
                        newp.X -= range;
                    }
                    else
                    {
                        newp = ramP(stp, direction + 1, rs);
                    }
                    break;
                case 4:
                    for (int i = stp.Y; i >= stp.Y - range && valid; i--)
                    {
                        if (stp.Y + range < 1) valid = false;
                        if (marked[stp.X, i] == true) valid = false;
                    }
                    if (valid)
                    {
                        newp.Y -= range;
                    }
                    else
                    {
                        newp = ramP(stp, direction + 1, rs);
                    }
                    break;
                default:
                    break;
            }
            for(int i = stp.X; i <= newp.X; i++)
            {
                for(int j = stp.Y; j <= newp.Y; j++)
                {
                    marked[i, j] = true;
                }
            }
            return newp;
        }
    }
}
