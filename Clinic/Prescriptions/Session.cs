using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    // Mediator class! It mediates the interactions between Therapists, Users and Treatments under the Session
    public class Session : Entity<int>, IAnotable
    {
        private int _idPrescription;
        private string _note;

        public string Note { get => _note; set => _note = value; }
        public int IDPrescription { get => _idPrescription; set => _idPrescription = value; }
        public override string ToString()
        {
            return _idPrescription + "," + _note;
        }
    }
}
