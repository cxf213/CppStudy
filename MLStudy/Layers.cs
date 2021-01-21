using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy
{
    class FlatLayer
    {
        float[] paras;
        float[] bias;
        float[] datas;
        float[] origindata;

        float[] ddata;

        float learnRate = 0.1f;
        public FlatLayer(int N)
        {
            paras = new float[N * N];
            bias = new float[N];
            ddata = new float[N];
            Initiate();
        }

        public void Initiate()
        {
            paras = new float[] { 0.1f, 0.3f, 0.2f, 0.4f };
            bias = new float[] { 0.7f, 0.8f };
        }
        public float[] Calculate(float[] data)
        {
            datas = data;
            origindata = data;
            return Networks.ListAdd(Networks.ListMulti(datas, paras), bias);
        }
        public void Callback(float[] x)
        {

        }

    }

    class NodeLayer
    {

        float[] paras;
        float[] bias;
        float[] datas;
        float[] origindata;

        float[] ddata;

        float learnRate = 0.1f;
        public NodeLayer(int N)
        {
            ddata = new float[N];
            paras = new float[N];
            bias = new float[1];
            Initiate();
        }

        public void Initiate()
        {
            paras = new float[] { 0.5f, 0.6f };
            bias = new float[] { 0.9f };
        }

        public float Calculate(float[] data)
        {
            datas = data;
            origindata = data;
            return Networks.ListMulAdd(datas, paras) + bias[0];
        }

        public float[] Callback(float x)
        {
            ddata = Networks.ListMulti(paras, x);

            bias[0] -= x;
            paras = Networks.ListDimi(paras, Networks.ListMulti(origindata, x * learnRate));
            return ddata;

        }
    }
}
