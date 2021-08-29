using System;
using System.Collections.Generic;
using System.Text;

namespace _2th_task
{
    interface IFormatting
    {
        public void Check(ref string text, ref int numerator);
    }
    class DelHtml : IFormatting
    {
        private int start;
        private int length;
        private bool progressing;
        
        public DelHtml()
        {
            start = 0;
            length = 0;
            progressing = false;
        }

        public void Check(ref string text, ref int numerator)
        {
            if (!progressing && text[numerator] == '<')
            {
                start = numerator;
                progressing = true;
            }

            if (progressing && text[numerator] == '>')
            {
                length = numerator - start + 1;
                text = text.Remove(start, length);
                numerator -= length;
                progressing = false;
            }
        }
    }

    class DelDash : IFormatting
    {
        public void Check(ref string text, ref int numerator)
        {
            try
            {
                if (text[numerator] == '-' && (text[numerator - 1] == ' ' || text[numerator + 1] == ' '))
                {
                    text = text.Remove(numerator, 1);
                    numerator--;
                }
            }
            catch
            {
                return;
            }
        }
    }

}
