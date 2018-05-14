namespace breakoutbox.Models.OefeningViewModel
{
    public class FeedbackViewModel
    {
        public FeedbackViewModel()
        {
            
        }

        public FeedbackViewModel(Groep groep, string feedback)
        {
            Groep = groep;
            Feedback = feedback;
        }
        
        public Groep Groep { get; set; }
        public string Feedback { get; set; }
        
    }
}