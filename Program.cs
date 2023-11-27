using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ValidationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running validation test using attributes...\n");
            AttributeTest();
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using default ruleset...\n");
            UseFacade<BusinessObjects.NoConfigPerson>("");
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using Rule1...\n");
            UseFacade<BusinessObjects.NoConfigPerson>("Rule1");
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using Over18 rule...\n");
            BusinessObjects.RuleSetPerson person = new BusinessObjects.RuleSetPerson();
            person.DOB = new DateTime(1980, 1, 1);
            UseRuleSet<BusinessObjects.RuleSetPerson>("Over18", person);
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using 18To25 rule...\n");
            BusinessObjects.RuleSetPerson person2 = new BusinessObjects.RuleSetPerson();
            person.DOB = new DateTime(1980, 1, 1);
            UseRuleSet<BusinessObjects.RuleSetPerson>("18to25", person2);
            Console.WriteLine("*******************************************");


            // Validation test using app.config settings

            Console.WriteLine("Running validation test using DefaultRule...\n");
            UseRuleSet<BusinessObjects.Person>("DefaultRule", new BusinessObjects.Person());
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using Over18 rule...\n");
            BusinessObjects.Person person3 = new BusinessObjects.Person();
            person.DOB = new DateTime(1980, 1, 1);
            UseRuleSet<BusinessObjects.Person>("Over18", person3);
            Console.WriteLine("*******************************************");

            Console.WriteLine("Running validation test using 18To25 rule...\n");
            BusinessObjects.Person person4 = new BusinessObjects.Person();
            person.DOB = new DateTime(1980, 1, 1);
            UseRuleSet<BusinessObjects.Person>("18to25", person4);
            Console.WriteLine("*******************************************");

            // SelfValidation example 
            Console.WriteLine("Running self validation test...\n");
            BusinessObjects.SelfValidateAddress address = new BusinessObjects.SelfValidateAddress();
            UseRuleSet<BusinessObjects.SelfValidateAddress>("", address);
            Console.WriteLine("*******************************************");


            Console.ReadLine();
        }

        static void AttributeTest()
        {
            BusinessObjects.NoConfigPerson person = new BusinessObjects.NoConfigPerson();
            person.ID = 0;
            // All validators will fail at this ppoint because the person has not been
            // initialized
            CheckResults(Validation.Validate<BusinessObjects.NoConfigPerson>(person));
            Console.WriteLine("---------");

            person.StartDate = DateTime.Now.AddYears(-1);
            person.EndDate = DateTime.Now;

            // The Start and End date validators will pass 
            CheckResults(Validation.Validate<BusinessObjects.NoConfigPerson>(person));
            Console.WriteLine("---------");

            person.DOB = DateTime.Now.AddMonths(-1);

            // StartDate validator will fail because the DOB is after the start date
            CheckResults(Validation.Validate<BusinessObjects.NoConfigPerson>(person));
            Console.WriteLine("---------");

            //person.Address = new BusinessObjects.Address("Main St", "Anytown", "USA", 12345);

            // Address will be evaluated and State validator will fail
            CheckResults(Validation.Validate<BusinessObjects.NoConfigPerson>(person));
            Console.WriteLine("---------");

            person.Address = new BusinessObjects.Address("Main St", "Anytown", "US", 12345);

            // Validating the address will show success
            CheckResults(Validation.Validate<BusinessObjects.Address>(person.Address));
        }

        static void UseFacade<T>(string RuleSet) where T : new()
        {
            T obj = new T();
            Validator<T> validator = ValidationFactory.CreateValidator<T>(RuleSet);
            CheckResults(validator.Validate(obj));
        }

        static void UseRuleSet<T>(string RuleSet, T person)
        {
            Validator<T> validator = ValidationFactory.CreateValidator<T>(RuleSet);
            CheckResults(validator.Validate(person));
        }

        /// <summary>
        /// Display the results of validation
        /// </summary>
        /// <param name="results"></param>
        static void CheckResults(ValidationResults results)
        {
            // Check if the validation was successful
            if(results.IsValid)
            {
                Console.WriteLine("Validation successful");
            }
            else
            {
                foreach(ValidationResult result in results)
                {
                    Console.WriteLine(result.Tag + ":" + result.Key + ":" + result.Message);
                }
            }
        }
    }
}
