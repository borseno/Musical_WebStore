using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class TestEnrollingModel
    {
        public int GoodId { get; set; }

        [LaterThanNowDate(ErrorMessage = "Date should be today or later")]
        public DateTime DateTime { get; set; }

        public string Comment { get; set; }
    }

    public class LaterThanNowDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) 
            => value is DateTime date && date.Date >= DateTime.Now.Date;
    }
}
