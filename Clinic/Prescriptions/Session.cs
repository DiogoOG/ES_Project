using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    // Mediator class! It mediates the interactions between Therapists, Users and Treatments under the Session
    public class Session : IAnotable
    {
        private List<Prescription> _prescriptions;
        private string _note;

        public string Note { get => _note; set => _note = value; }
    }
}
