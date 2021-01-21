using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MLStudy
{
    class examML
    {
        NodeLayer layer2;
        FlatLayer layer1;
        float[] datas;
        float cost = 0f;
        float ans;
        public examML()
        {
            layer1 = new FlatLayer(2);
            layer2 = new NodeLayer(2);
        }

        public float Calculate(float[] data)
        {
            datas = data;
            datas = layer1.Calculate(datas);
            datas = Networks.Sigmoid(datas);

            ans = layer2.Calculate(datas);
            ans = Networks.Sigmoid(ans);
            return ans;
        }

        public void Callback(float exceptAns)
        {
            float dSig = Networks.Dcost(ans,exceptAns)* Networks.Dsigmoid(ans);
            layer2.Callback(dSig);
        }
    }
}
