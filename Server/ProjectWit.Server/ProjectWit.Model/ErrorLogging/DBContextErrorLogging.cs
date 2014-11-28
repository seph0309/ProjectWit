using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectWit.Model.ErrorLogging
{
    public class DBContextErrorLogging
    {
        private List<ValidationResult> _errors;
        protected List<string> dbContextErrorLogMsg { get; set; }
 
        public DBContextErrorLogging()
        {
            dbContextErrorLogMsg = new List<string>();
        }

        /// <summary>
        /// This converts the Entity framework errors into Validation errors
        /// </summary>
        public void SetErrors(IEnumerable<DbEntityValidationResult> errors)
        {
            _errors =
                errors.SelectMany(
                    x => x.ValidationErrors.Select(y =>
                          new ValidationResult(y.ErrorMessage, new[] { y.PropertyName })))
                    .ToList();
            foreach(var error in _errors)
            {
                dbContextErrorLogMsg.Add(error.ErrorMessage);
            }
        }
    }
}
