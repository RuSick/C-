using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSQL;

namespace Data_layer
{
    public class Data_Layer
    {

        public Rep rep { get; set; }
        public Data_Layer(string connectionString)
        {
            rep = new Rep(connectionString);
        }
    }

}
