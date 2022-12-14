using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox12_6
{
    interface IEditing
    {
        void FullNameEditing(int indexFind, string fullName);
        int FindTelNum(string phoneNumber);
        void RechargeTelNum(int indexFind, string phoneNumber);
        void PassportEditing(int indexFind, string passportData);
    }
}
