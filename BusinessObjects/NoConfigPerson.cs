using System;
using System.Collections.Generic;
using System.Text;

// Need these to make it work
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace BusinessObjects
{
    /// <summary>
    /// Example business object class that uses
    /// attributes to define validation rules
    /// </summary>
    public class NoConfigPerson
    {
        [RangeValidator(1, RangeBoundaryType.Inclusive, 500, RangeBoundaryType.Inclusive)]
        private int m_ID;
        private string m_FirstName = null;
        private string m_LastName;
        private string m_Email;
        private DateTime m_DOB;
        private Address m_Address;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        public NoConfigPerson()
        {
        }

        #region Properties

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        [StringLengthValidator(1, 20)]
        [NotNullValidator]
        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        [NotNullValidator]
        [StringLengthValidator(1, 30)]
        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }

        [NotNullValidator]
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        [RelativeDateTimeValidator(18, DateTimeUnit.Year, 25, DateTimeUnit.Year)]
        [DateTimeRangeValidator("1960-01-01T00:00:00", "2007-01-01T00:00:00")]
        public DateTime DOB
        {
            get { return m_DOB; }
            set { m_DOB = value; }
        }

        [ObjectValidator]
        public Address Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }

        [ValidatorComposition(CompositionType.Or)]
        [PropertyComparisonValidator("EndDate", ComparisonOperator.LessThan)]
        [PropertyComparisonValidator("DOB", ComparisonOperator.GreaterThan)]
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        
        [PropertyComparisonValidator("StartDate", ComparisonOperator.GreaterThan)]
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        #endregion
    }
}
