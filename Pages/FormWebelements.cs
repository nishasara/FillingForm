using System;
using System.Collections.Generic;
using System.Text;

namespace FormTesting.Pages
{
    public class FormWebelements
    {
        public String FirstName;
        public String LastName;
        public String Email;
        public String Message;

        public FormWebelements(String FirstName, String LastName, String Email, String Message)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Message = Message;
        }
    }
}
