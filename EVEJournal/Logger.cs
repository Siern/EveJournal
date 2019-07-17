using System;
using System.Collections.Generic;
using System.Text;

namespace EVEJournal
{
    internal static class Logger
    {
        private static System.Windows.Forms.RichTextBox m_TextBox = null;

        public static void SetLogger(System.Windows.Forms.RichTextBox TextBox)
        {
            m_TextBox = TextBox;
        }

        public static void ReportError(string Message)
        {
            m_TextBox.Text += "Error: " + Message + "\n";
        }

        public static void ReportWarning(string Message)
        {
            m_TextBox.Text += "Warning: " + Message + "\n";
        }

        public static void ReportNotice(string Message)
        {
            m_TextBox.Text += "Notice: " + Message + "\n";
        }
    }
}
