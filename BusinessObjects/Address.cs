using System;
using System.Collections.Generic;
using System.Text;

// Need these to make it work
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace BusinessObjects
{
    public class Address
    {
        private string m_Address;
        private string m_City;
        private string m_State;
        private int m_Zip;

        public Address(string Address, string City, string State, int Zip)
        {
            this.Address1 = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = Zip;
        }

        #region Properties

        [NotNullValidator]
        public string Address1
        {
            get { return m_Address; }
            set { m_Address = value; }
        }

        public string City
        {
            get { return m_City; }
            set { m_City = value; }
        }

        [StringLengthValidator(1,2)]
        public string State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public int ZipCode
        {
            get { return m_Zip; }
            set { m_Zip = value; }
        }

        #endregion
    }
}
