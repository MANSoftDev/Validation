using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    /// <summary>
    /// Example business object class
    /// </summary>
    public class Person
    {
        private int m_ID;
        private string m_FirstName = null;
        private string m_LastName;
        private string m_Email;
        private DateTime m_DOB;
        private Address m_Address;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        public Person()
        {
        }

        #region Properties

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public DateTime DOB
        {
            get { return m_DOB; }
            set { m_DOB = value; }
        }

        public Address Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }

        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        #endregion
    }
}