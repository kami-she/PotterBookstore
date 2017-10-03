using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookstore
{
    public interface IProduct
    {
        decimal Price { get; }

        string Name { get; }
    }
}
