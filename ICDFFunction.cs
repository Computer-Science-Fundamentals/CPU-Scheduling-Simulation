using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    interface ICDFFunction
    {
        Double ComputeCDF(Random rnd);
        int GenerateBurstTime(Random rnd);
    }
}
