using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAssets;

namespace Clinic
{
    // Mediator class! It mediates the interactions between all the entities involved
    public class Prescription
    {
        private IPrescriptionable _prescriptionable;    // What
        private TimeSlot _schedule;                     // When
        private User[] _users;                          // Who
        private bool _public;                           // Is it public?
        private List<User> _permissions;                // List of those that have access permissions (if private)

        public IPrescriptionable Prescriptionable => _prescriptionable;
        public TimeSlot Schedule => _schedule;
        public Patient Patient => (Patient)_users[0];
        public Therapist Therapist => (Therapist)_users[1];

        public bool HasPermission(User user) => _public || _permissions.Contains(user);
        public void AddPermission(User user) => _permissions.Add(user);

        public override string ToString() => $"P: {Patient} T: {Therapist} => {Prescriptionable.Name} @ {Schedule}" ;
    }
}
