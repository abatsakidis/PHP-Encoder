using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IlluminationTools.Random;
using IlluminationTools.Constants;
using System.IO;
using System.Threading;

namespace IlluminationTools.Encrypt
{
    public class IEncodePHP
    {
        SymmCrypto objCrypto = new SymmCrypto(SymmCrypto.SymmProvEnum.Rijndael);
        StreamWriter writeLog;

        public IEncodePHP()
        {

        }

        public IEncodePHP(StreamWriter prmWriteLog)
        {
            this.writeLog = prmWriteLog;
        }


        public void GetFileInDirectory(string encodePath, int level, string decodePath)
        {
            DirectoryInfo dir = new DirectoryInfo(encodePath.Trim());
            DirectoryInfo[] directory = dir.GetDirectories();
            FileInfo[] bmpfiles = dir.GetFiles("*.*");

            int totalFile = bmpfiles.Length;
            foreach (FileInfo f in bmpfiles)
            {
                string fileName = f.Name.ToString();

                long lengthOfFile = f.Length;
                DateTime createTimeFile = f.CreationTime;
                FileAttributes fileAttributes = f.Attributes;
                string sourceFilePath = encodePath + @"\" + fileName;
                string encodeFilePath = decodePath + @"\" + fileName;
                if (File.Exists(sourceFilePath))
                {
                    if (!File.Exists(encodeFilePath))
                    {

                        CreateFile(sourceFilePath, encodeFilePath);
                    }
                }
            }

            foreach (DirectoryInfo f in directory)
            {
                string folderName = f.Name.ToString();
                DateTime createTimeFile = f.CreationTime;
                FileAttributes folderAttributes = f.Attributes;

                level++;
                string strEncodepath = encodePath + @"\" + folderName;
                string strDecodePath = decodePath + @"\" + folderName;
                //Create decode path

                if (!File.Exists(strDecodePath))
                {
                    CreateFolder(decodePath, folderName);
                }
                GetFileInDirectory(strEncodepath, level, strDecodePath);
            }

        }

        private void CreateFolder(string parentPath, string folder)
        {
            try
            {
                string path = parentPath + @"\" + folder;
                if (!File.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(parentPath);
                    dir.CreateSubdirectory(folder);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateFile(string sourceFilePath, string encodeFilePath)
        {

            string sourceExt = GetExtOfFile(sourceFilePath);
            string[] arrExtAllow = { "php", "inc" };

            if (!IsAllowEncode(arrExtAllow, sourceExt))
            {
                File.Copy(sourceFilePath, encodeFilePath, true);
            }
            else
            {
                FileInfo fi = new FileInfo(encodeFilePath);
                FileStream fstr = fi.Create();
                fstr.Close();

                Main._Main1.update("Filename: " + fi.Name.ToString() + "\r\n");
                Application.DoEvents();

                FileInfo f = new FileInfo(encodeFilePath);
                StreamWriter w = f.CreateText();

                StreamReader SR;
                SR = File.OpenText(sourceFilePath);
                encodeFile(SR, w);
                w.Close();

            }
        }

        private void encodeFile(StreamReader streamReader, StreamWriter streamWriter)
        {
            Boolean isStartPhp = false;
            Boolean isStartStringSingle = false;
            Boolean isStartStringDouble = false;
            Boolean isStartCommentPar = false;
            Boolean isStartScript = false;

            string lineStr;
            string beforeLine = string.Empty;
            lineStr = streamReader.ReadLine();            

            ArrayList arrToEncode = CreateNewArr();
            ArrayList arrNotEncode = CreateNewArr();
            
            string strIndex = string.Empty;
            ArrayList arrReturn = CreateNewArr();
            
            int newLineLength = IlluminationConstants.newLineScript.Length;

            while (lineStr != null)
            {

                if (isStartScript)
                {

                    string scriptLine = lineStr.Trim();


                    if (!isStartCommentPar)
                    {
                        lineStr = scriptLine + IlluminationConstants.newLineScript;
                    }
                }

                lineStr = lineStr.Trim() + " ";
                string strEncode = string.Empty;
                strEncode = lineStr;


                char[] arrS = lineStr.ToCharArray();
                if (lineStr.Trim().Contains("IP,name="))
                {
                }
                if (isStartStringSingle != isStartStringDouble)
                {
                }
                for (int i = 0; i < arrS.Length; i++)
                {
                    string strCheckOneChar = string.Empty;
                    string strCheckTwoChar = string.Empty;
                    string strCheckFiveChar = string.Empty;
                    string strCheckEightChar = string.Empty;
                    string strCheckNineChar = string.Empty;

                    strCheckOneChar = GetStringToCheck(arrS, i, 1);
                    strCheckTwoChar = GetStringToCheck(arrS, i, 2);
                    strCheckEightChar = GetStringToCheck(arrS, i, 8);
                    strCheckNineChar = GetStringToCheck(arrS, i, 9);

                    string currenChar = arrS.GetValue(i).ToString();
                    if (strCheckTwoChar.Equals(IlluminationConstants.startCommentPHP.ToLower()))
                    {
                        isStartCommentPar = true;
                    }

                    if (strCheckTwoChar.Equals(IlluminationConstants.endCommentPHP.ToLower()))
                    {
                        isStartCommentPar = false;
                    }

                    if (strCheckEightChar.Equals(IlluminationConstants.startScript.ToLower()))
                    {
                        isStartScript = true;
                    }

                    if (strCheckNineChar.Equals(IlluminationConstants.endScript.ToLower()))
                    {
                        isStartScript = false;
                    }

                    Encoding ascii = Encoding.ASCII;
                    Byte[] encodedBytes = ascii.GetBytes(arrS.GetValue(i).ToString());
                    foreach (Byte b in encodedBytes)
                    {
                        if (!isStartCommentPar)
                        {
                            if (strCheckTwoChar.Equals(IlluminationConstants.sigleString))
                            {
                                string checkBackslashString = string.Empty;
                                if (i > 0)
                                {
                                    checkBackslashString = GetStringToCheck(arrS, i - 1, 1);
                                }
                                if (!checkBackslashString.Equals(IlluminationConstants.backslashString))
                                {
                                    isStartStringDouble = !isStartStringDouble;
                                }
                            }
                            if (Convert.ToInt32(b) == Convert.ToInt32(IlluminationConstants.asciiSingleTenTen))
                            {
                                isStartStringSingle = !isStartStringSingle;
                                if (isStartStringDouble)
                                {
                                    isStartStringSingle = false;
                                }
                            }
                            if (Convert.ToInt32(b) == Convert.ToInt32(IlluminationConstants.asciiDoubleTenTen))
                            {

                                
                                string oneAfterHere = string.Empty;
                                string twoAfterHere = string.Empty;
                                if (arrS.Length > i + 2)
                                {
                                    oneAfterHere = GetStringToCheck(arrS, i + 1, 1);
                                    twoAfterHere = GetStringToCheck(arrS, i + 2, 1);
                                    if (oneAfterHere.Equals("/"))
                                    {
                                        Byte[] encodedBytes1 = ascii.GetBytes(twoAfterHere);
                                        foreach (Byte b1 in encodedBytes1)
                                        {
                                            if (Convert.ToInt32(b1) == Convert.ToInt32(IlluminationConstants.asciiDoubleTenTen))
                                            {
                                                if (isStartStringDouble != isStartStringSingle)
                                                {
                                                    isStartStringDouble = !isStartStringDouble;
                                                }
                                            }
                                        }
                                    }
                                }
                                

                                isStartStringDouble = !isStartStringDouble;
                                if (isStartStringSingle)
                                {
                                    isStartStringDouble = false;
                                }
                            }
                        }
                        break;
                    }

                    if (strCheckOneChar.Equals(IlluminationConstants.startCommentLinePHP) || strCheckTwoChar.Equals(IlluminationConstants.startCommentLineJava))
                    {
                        
                        {
                        
                            if (!isStartStringSingle && !isStartStringDouble)
                            {
                                if (i == 0)
                                {
                                    break;
                                }

                                string strTmp = lineStr.Substring(0, i);
                                string checkNewLine = GetStringToCheck(arrS, i, 24);
                                string strCheckNewLine = "/" + IlluminationConstants.newLineScript;
                                if (!(strCheckNewLine.ToLower().Equals(checkNewLine.ToLower())))
                                {
                                    arrS = strTmp.ToCharArray();
                                }
                            }
                        }
                    }

                    
                    if (strCheckTwoChar.Equals(IlluminationConstants.endPhp.ToLower()))
                    {
                        if (!isStartScript)
                        {
                            if (!isStartCommentPar)
                            {
                                if (!isStartStringSingle && !isStartStringDouble)
                                {
                                    isStartPhp = false;

                                    string strEncoded = EncodePHP(arrToEncode);

                                    AddCharToArr(arrNotEncode, strEncoded);
                                    strIndex = strIndex + strEncoded;
                                    arrToEncode = CreateNewArr();
                                    isStartPhp = false;
                                    isStartStringSingle = false;
                                    isStartStringDouble = false;
                                    isStartCommentPar = false;
                                }
                            }
                        }
                    }

                    
                    strCheckFiveChar = GetStringToCheck(arrS, i, 5);
                    if (strCheckFiveChar.Equals(IlluminationConstants.startPhp.ToLower()) || strCheckTwoChar.Equals(IlluminationConstants.startPhpMissing.ToLower()))
                    {
                        if (!isStartScript)
                        {
                            if (!isStartPhp)
                            {
                                if (!isStartCommentPar)
                                {
                                    isStartPhp = true;
                                    isStartStringSingle = false;
                                    isStartStringDouble = false;
                                    isStartCommentPar = false;

                                    if (strCheckFiveChar.Equals(IlluminationConstants.startPhp.ToLower()))
                                    {
                                        i += 5; 
                                    }
                                    else
                                    {
                                        i += 2; 
                                    }
                                    AddCharToArr(arrNotEncode, IlluminationConstants.startPhp);
                                    strIndex = strIndex + IlluminationConstants.startPhp;
                                }
                            }
                        }
                    }

                    try
                    {
                        if (!isStartPhp)
                        {
                            AddCharToArr(arrNotEncode, arrS.GetValue(i).ToString());

                            strIndex = strIndex + arrS.GetValue(i).ToString();
                            if (isStartScript)
                            {
                                if (strIndex.Length > newLineLength)
                                {
                                    string checkLine = strIndex.Substring(strIndex.Length - newLineLength, newLineLength);
                                    if (checkLine.ToLower().Equals(IlluminationConstants.newLineScript.ToLower()))
                                    {
                                        string sourceLine = strIndex.Substring(0, strIndex.Length - newLineLength);
                                        arrReturn.Add(sourceLine);
                                        strIndex = string.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            AddCharToArr(arrToEncode, arrS.GetValue(i).ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                beforeLine = lineStr;
                lineStr = streamReader.ReadLine();
            }
            if (isStartPhp)
            {
                isStartPhp = false;

                string strEncoded = EncodePHP(arrToEncode);
                arrToEncode = CreateNewArr();

                AddCharToArr(arrNotEncode, strEncoded);
                strIndex = strIndex + strEncoded;
                AddCharToArr(arrNotEncode, IlluminationConstants.endPhp);
                strIndex = strIndex + IlluminationConstants.endPhp;

            }
            if (!strIndex.Trim().Equals(string.Empty))
            {
                arrReturn.Add(strIndex);
            }

            for (int iLineStart = 0; iLineStart < arrReturn.Count; iLineStart++)
            {
                string lineStartExecute;
                lineStartExecute = arrReturn[iLineStart].ToString();
                lineStartExecute = lineStartExecute.Replace(IlluminationConstants.newLineScript, "");
                streamWriter.WriteLine(lineStartExecute);
            }

            streamReader.Close();
        }

        public ArrayList Split(string strSource, string separator)
        {
            ArrayList arrIndex = CreateNewArr();
            ArrayList arrReturn = CreateNewArr();
            string strLine = string.Empty;
            int speratorLength = separator.Length;

            char[] arrSource = strSource.ToCharArray();
            for (int i = 0; i < arrSource.Length; i++)
            {
                string currentChar = arrSource.GetValue(i).ToString();
                string currentString = GetStringToCheck(arrSource, i, speratorLength);
                if (currentString.Equals(separator.ToLower()))
                {
                    strLine = ConvertToString(arrIndex);
                    arrReturn.Add(strLine);
                    strLine = string.Empty;
                    i += speratorLength - 1;
                    arrIndex = CreateNewArr();
                }
                else
                {
                    AddCharToArr(arrIndex, currentChar);
                }
            }
            strLine = ConvertToString(arrIndex);
            arrReturn.Add(strLine);

            return arrReturn;
        }

        private bool CheckToAddBreak(string scriptLine)
        {
            string checkElse = " " + IlluminationConstants.startElse;
            if (scriptLine.Contains(IlluminationConstants.startPhp))
            {
                return false;
            }
            if (scriptLine.Contains(IlluminationConstants.startElse))
            {
                return false;
            }
            if (scriptLine.Contains(checkElse))
            {
                return false;
            }
            return true;
        }

        private string GetFinalChar(string str)
        {
            str = str.Trim();
            if (str != string.Empty)
            {
                return str.ToCharArray().GetValue(str.ToCharArray().Length - 1).ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetFirstChar(string str)
        {
            str = str.Trim();
            if (str != string.Empty)
            {
                return str.ToCharArray().GetValue(0).ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetStringToCheck(char[] arrS, int startCheck, int lengthCheck)
        {
            int i = startCheck;
            ArrayList arrCheckFiveChar = CreateNewArr();
            string strCheckFiveChar = string.Empty;

            for (int j = i; j < arrS.Length; j++)
            {
                if (j == i + lengthCheck)
                {
                    break;
                }
                AddCharToArr(arrCheckFiveChar, arrS.GetValue(j).ToString());
            }
            strCheckFiveChar = ConvertToString(arrCheckFiveChar).ToLower();
            return strCheckFiveChar;
        }

        private string EncodePHP(ArrayList arrToEncode)
        {
            
            string strToEncode = ConvertToString(arrToEncode);
            strToEncode = strToEncode.Replace(IlluminationConstants.newLineScript, "");
            string strEncode1 = EncodePHP(objCrypto.Encrypt64(strToEncode));
            
            for (int i = 0; i < 4; i++)
            {
                strEncode1 = EncodePHP(objCrypto.Encrypt64(strEncode1));
            }
            return EncodePHP(objCrypto.Encrypt64(strEncode1));
        }

        private string EncodePHP(string strEncoded)
        {
            string variable1 = IRandom.GetRandomString(4, false, false);
            string variable2 = IRandom.GetRandomString(3, false, false);
            string variable3 = IRandom.GetRandomString(2, false, false);

            string startVariable = " $" + variable1 + " = '";
            string endVariable = "';";
            string strDecode = "$" + variable3 + " = '$" + variable2 + " = base64_decode($" + variable1 + "); eval($" + variable2 + ");';";
            string strEval = "eval($" + variable3 + ");";
            strEncoded = startVariable + strEncoded + endVariable + strDecode + strEval;
            return strEncoded;
        }

        private bool IsContant(string str1, string str2)
        {
            return str1.ToLower().Contains(str2.ToLower());
        }

        private string GetExtOfFile(string fileName)
        {
            if (fileName.Trim().Equals(String.Empty))
            {
                return String.Empty;
            }

            string[] arrExt;
            arrExt = fileName.Split('.');
            return arrExt.GetValue(arrExt.Length - 1).ToString();
        }

        private bool IsAllowEncode(string[] arrExtAllow, string sourceExt)
        {
            for (int i = 0; i < arrExtAllow.Length; i++)
            {
                string ext = arrExtAllow.GetValue(i).ToString();

                if (sourceExt.ToLower().Trim().Equals(ext.ToLower().Trim()))
                {
                    return true;
                }
            }
            return false;
        }

        private ArrayList CreateNewArr()
        {
            return new ArrayList();
        }

        private void AddCharToArr(ArrayList arrList, char chr)
        {
            if (arrList == null)
            {
                arrList = new ArrayList();
            }
            arrList.Add(chr);
        }

        private void AddCharToArr(ArrayList arrList, string chr)
        {
            if (arrList == null)
            {
                arrList = new ArrayList();
            }
            arrList.Add(chr);
        }

        private string ConvertToString(ArrayList arrList)
        {
            string result = string.Empty;
            for (int i = 0; i < arrList.Count; i++)
            {
                result = result + arrList[i].ToString();
            }
            return result;
        }
    }
}
