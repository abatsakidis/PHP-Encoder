using System;
using System.Collections.Generic;
using System.Text;

namespace IlluminationTools.Constants
{
    public class IlluminationConstants
    {
        public const string startPhp = "<?php";
        public const string startPhpMissing = "<?";
        public const string endPhp = "?>";

        public const string startScript = "<script ";
        public const string endScript = "</script>";

        public const string startIf = "if";
        public const string startElse = "else";
        public const string startFor = "for";
        public const string startWhile = "while";
        public const string startSwitch = "switch";
        public const string startExecute = "{";
        public const string endExecute = "}";
        public const string startCondition = "(";
        public const string endCondition = ")";
        public const string strChoose = ":";
        public const string strBreak = ";";
        public const string strPoint = ",";
        public const string strStartTag = "<";
        public const string strEndTag = ">";
        public const string strStartCommentXml = "<!--";
        public const string strEndCommentXml = "-->";
        public const string strSub = "/";
        public const string strMultiple = "*";
        public const char charNewLine = '¬';

        public const string newLineScript = "/*IlluminationNewLine*/";
        public const string commentErrorLine = "/*errorLine*/";

        // Don't write
        public const string startCommentLinePHP = "#"; // # = 35
        public const string startCommentLineJava = "//";
        public const string startCommentPHP = "/*";
        public const string endCommentPHP = "*/";
        public const string sigleString = "\\\"";
        public const string backslashString = "\\";

        // Allow Write
        public const int asciiSingleTenTen = 39; // ' = 39
        public const int asciiDoubleTenTen = 34; // " = 34

        public IlluminationConstants()
        {

        }
    }
}
