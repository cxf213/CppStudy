#define SHOWa


namespace MLStudy
{
    class FlatLayer
    {
        int N = 0;
        float[] paras;
        float[] bias;
        float[] datas;
        float[] origindata;

        float[] ddata;

        float learnRate = 1f;
        public FlatLayer(int N)
        {
            this.N = N;
            paras = new float[N * N];
            bias = new float[N];
            ddata = new float[N];
            Initiate();
        }

        public void Initiate()
        {
            paras = new float[] { 0.1f, 0.3f, 0.2f, 0.4f      };
            bias = new float[] { 0.7f, 0.8f  };
        }
        public float[] Calculate(float[] data)
        {
            datas = data;
            origindata = data;
            return Networks.ListAdd(Networks.ListMulti(datas, paras), bias);
        }
        public void Callback(float[] x)
        {
            this.bias = Networks.ListDimi(bias, x);
            float[] dparas = new float[N*N];
            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dparas[i * N + j] = origindata[i] * x[j] * learnRate;
                }
            }
            this.paras = Networks.ListDimi(paras, dparas);
#if SHOW
            string s = "";
            foreach (var i in dparas)
                s += i + "\n";
            s += "\n";
            foreach (var i in x)
                s += i + "\n";

            System.Windows.MessageBox.Show(s);
#endif
        }

    }

    class NodeLayer
    {
        int N = 0;
        float[] paras;
        float[] bias;
        float[] datas;
        float[] origindata;

        float[] ddata;

        float learnRate = 1f;
        public NodeLayer(int N)
        {
            this.N = N;
            ddata = new float[N];
            paras = new float[N];
            bias = new float[1];
            Initiate();
        }

        public void Initiate()
        {
            paras = new float[] { 0.5f, 0.6f  };
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
#if SHOW
            string s = "";
            foreach (var i in Networks.ListMulti(origindata, x * learnRate))
                s += i + "\n";
            s += "\n";
            s += x;
            System.Windows.MessageBox.Show(s);
#endif
            return ddata;

        }
    }
}
