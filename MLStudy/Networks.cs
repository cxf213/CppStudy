﻿using System;

namespace MLStudy
{
    class Networks
    {

        public static float[] ListMulAdds(float[] data, float[] y)
        {
            float[] sum = new float[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                sum[i] = data[i] * y[i];
            }
            return sum;
        }
        public static float ListMulAdd(float[] data, float[] y)
        {
            float sum = 0f;
            for(int i = 0; i < data.Length; i++)
            {
                sum += data[i] * y[i];
            }
            return sum;
        }

        /// <summary>
        /// 矩阵与矩阵乘积
        /// </summary>
        /// <param name="data">矩阵1</param>
        /// <param name="y">矩阵2</param>
        /// <returns></returns>
        public static float[] ListMulti(float[] data, float[] y)
        {
            int len = data.Length;
            float[] ans = new float[len];
            if (len*len != y.Length) return ans;
            for(int i = 0; i < len; i++)
            {
                for(int j = 0; j < len; j++)
                {
                    ans[j] += data[i] * y[j + i * len];
                }
            }
            return ans;
        }

        public static float[] ListMulti(float[] data, float y)
        {
            int len = data.Length;
            float[] ans = new float[len];
            for(int i = 0; i < len; i++)
            {
                ans[i] = data[i] * y;
            }
            return ans;
        }
        public static float[] ListAdd(float[] x, float[] y)
        {
            int len = x.Length;
            float[] ans = new float[len];
            for (int i = 0; i < len; i++)
            {
                ans[i] = x[i] + y[i];
            }
            return ans;
        }
        /// <summary>
        /// 矩阵相减输出x-y
        /// </summary>
        /// <param name="x">被减数</param>
        /// <param name="y">减数</param>
        /// <returns></returns>
        public static float[] ListDimi(float[] x, float[] y)
        {
            int len = x.Length;
            float[] ans = new float[len];
            for (int i = 0; i < len; i++)
            {
                ans[i] = x[i] - y[i];
            }
            return ans;
        }

        public static float Sigmoid(float x) => 1 / (1 + MathF.Exp(-x));
        public static float[] Sigmoid(float[] x)
        {
            for(int i = 0; i < x.Length; i++)
            {
                x[i] = Sigmoid(x[i]);
            }
            return x;
        }

        public static float Dsigmoid(float x) => x * (1 - x);
        public static float[] Dsigmoid(float[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Dsigmoid(x[i]);
            }
            return x;
        }
        public static float ReLu(float x) => x > 0 ? x : 0;
        public static float DReLu(float x) => x > 0 ? 1 : 0;
        public static float[] ReLu(float[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = ReLu(x[i]);
            }
            return x;
        }
        public static float[] DReLu(float[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = DReLu(x[i]);
            }
            return x;
        }
        //TODO: 支持更多激活函数

        public static float Cost(float ans, float exceptans) => (exceptans - ans) * (exceptans - ans) / 2;
        public static float Dcost(float ans, float exceptans) => -1 * (exceptans - ans);

    }
}
