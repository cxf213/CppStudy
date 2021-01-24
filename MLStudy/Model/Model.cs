using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Model
{
    public interface Models
    {
        public float Calculate(float[] data);
        public void Callback(float exceptAns);
        public float Cost { get; set; }
    }
}
