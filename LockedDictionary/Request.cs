using System;

namespace UI
{
    public class Request
    {
        public int RequestId { get; set; }
        public int CallId { get; set; }
        public int? Requester { get; set; }

        private DateTime _Start;
        public DateTime Start
        {
            get { return _Start; }
            set
            {
                _Start = value; StartInfo = value.ToString("ss.ffffff");
            }
        }

        public string StartInfo { get; set; }
    }
}