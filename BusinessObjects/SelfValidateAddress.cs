using System;
using System.Collections.Generic;
using System.Text;

// Need these to make it work
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace BusinessObjects
{
    [HasSelfValidation]
    public class SelfValidateAddress
    {
        [SelfValidation]
        public void CheckState(ValidationResults results)
        {
            // Perform custom validation here

            ValidationResult result = new ValidationResult("State not correct", this, null, null, null);
            results.AddResult(result);
        }

        [SelfValidation]
        public void CheckZipCode(ValidationResults results)
        {
            // Perform custom validation here

            ValidationResult result = new ValidationResult("ZipCode does not match City", this, null, null, null);
            results.AddResult(result);
        }
    }
}
