using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Utils
{
    public interface State
    {
        void pushButton(Prescription prescription);
    }

    public class Private : State
    {
        public void pushButton(Prescription prescription)
        {
            prescription.setState(new Public());
        }
    }

    public class Public : State
    {
        public void pushButton(Prescription prescription)
        {
            prescription.setState(new Private());
        }
    }
}
