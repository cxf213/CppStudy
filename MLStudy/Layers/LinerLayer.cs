using System;
using System.Collections.Generic;
using System.Text;
using MLStudy.Libs;

namespace MLStudy.Layers
{
    class LinerLayer
    {
        private int inCount = 1, outCount = 1;
        MatrixF paras;
        float[] bias;
        float[] Inputs, DInputs;
        public float LearnRate { get; set; }

        public LinerLayer(int M, int N)
        {
            inCount = M;
            outCount = N;
            paras = new MatrixF(inCount, outCount, 1);
            bias = new float[outCount];
            Initiatize();
        }

        /// <summary>
        /// 仅供测试
        /// </summary>
        private void Initiatize()
        {
            //  | 0.1   0.2 |   | 1 |   | 0.7   |
            //  |           | . |   | + |       |   运算
            //  | 0.3   0.4 |   | 0 |   | 0.8   |

            paras = new MatrixF(new float[2, 2] { { 0.1f, 0.3f }, { 0.2f, 0.4f } });
            bias = new float[2] { 0.7f, 0.8f };
        }

        public float[] Forward(float[] data)
        {
            Inputs = (float[])data.Clone();
            data = Networks.ListAdd(paras.dot(data),bias);
            return data;
        }
        public float[] BackPropa(float[] ForwardDiff)
        {
            float[] BackDiff = new float[inCount];
            return BackDiff;
        }
    }
}
