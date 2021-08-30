using System.Text;

namespace _2th_task
{
    interface IFormatting
    {
        public void Check(ref StringBuilder text, int numerator);
    }
    class DelHtml : IFormatting
    {
        private int start;
        private bool progressing;

        public DelHtml()
        {
            start = 0;
            progressing = false;
        }

        public void Check(ref StringBuilder text, int numerator)
        {
            if (!progressing && text[numerator] == '<')
            {
                start = numerator;
                progressing = true;
            }

            if (progressing && text[numerator] == '>')
            {
                for (int i = start; i <= numerator; i++)
                    text[i] = ' ';
                progressing = false;
            }
        }                                   
    }

    class DelDash : IFormatting
    {
        public void Check(ref StringBuilder text, int numerator)
        {
            try
            {
                if (text[numerator] == '-' && (text[numerator - 1] == ' ' || text[numerator + 1] == ' '))
                    text[numerator] = ' ';
            }
            catch
            {
                return;
            }
        }
    }

}