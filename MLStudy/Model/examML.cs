using System;
using MLStudy.Layers;

namespace MLStudy.Model
{
    public class examML:Models
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

        public float Cost { get => cost; set => cost = value; }

        public float Calculate(float[] data)
        {
            datas = data;
            datas = layer1.Forward(datas);
            datas = Networks.Sigmoid(datas);

            ans = layer2.Forward(datas);
            ans = Networks.Sigmoid(ans);
            return ans;
        }

        public void Callback(float exceptAns)
        {
            cost = (ans - exceptAns) * (ans - exceptAns) / 2;
            float dSig = Networks.Dcost(ans,exceptAns)* Networks.Dsigmoid(ans);
            float[] dlayer1 = Networks.ListMulAdds(layer2.BackPropa(dSig) , Networks.Dsigmoid(datas)); //第二层的反向传播
            layer1.BackPropa(dlayer1);
        }
    }
}
