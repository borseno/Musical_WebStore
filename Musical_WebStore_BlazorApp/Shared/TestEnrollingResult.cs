using System;
using System.Collections.Generic;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class TestEnrollingResult
    {
        public bool IsSuccessful { get; set; }

        public int TestId { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
