using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic {
    public interface IPrescriptionable {
        string Name { get; set; }
        string Type { get; }
    }
}