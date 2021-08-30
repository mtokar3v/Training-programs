﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2th_task
{
    interface IFormatting
    {
        public void Check(ref string text, int numerator);
    }
    class DelHtml : IFormatting
    {
        private int start;
        private int length;
        private bool progressing;

        public DelHtml()
        {
            start = 0;
            progressing = false;
        }

        public void Check(ref string text, int numerator)
        {
            if (!progressing && text[numerator] == '<')
            {
                start = numerator;
                progressing = true;
            }

            if (progressing && text[numerator] == '>')
            {
                StringBuilder _text = new StringBuilder(text);

                for (int i = start; i <= numerator; i++)
                    _text[i] = ' ';

                text = _text.ToString();
                progressing = false;
            }
        }
    }

    class DelDash : IFormatting
    {
        public void Check(ref string text, int numerator)
        {
            try
            {
                if (text[numerator] == '-' && (text[numerator - 1] == ' ' || text[numerator + 1] == ' '))
                {
                    StringBuilder _text = new StringBuilder(text);
                    _text[numerator] = ' ';
                    text = _text.ToString();
                }
            }
            catch
            {
                return;
            }
        }
    }

}