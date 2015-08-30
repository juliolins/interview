using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class RecoverSentence
    {
    }
}

/*
"thisisaword"

"thereisacat"

bool IsWord(string);

"homelandsecurityisnecessary"

string Recover(string sentence) 
{
    if (sentence.Length == 1) 
    {
        return sentence;
    }
    
    return DoRecover(sentence, 0, 1);
}

string DoRecover(sting sentence, int start, int end) 
{


    if (end == sentence.Length) 
    {
        string tempWord = sentence.Substring(start, end);
        if (IsWord(tempWord) 
        {
            return tempWord;
        } 
        else 
        {
            return null;
        }
    } 
    else 
    {
        for (int i = start; i < sentence.Length; i++) 
        {
             string tempWord = sentence.Substring(start, i);
               
            if (IsWord(tempWord) 
            {
                string nextWord = DoRecover(sentence, start, i + 1);
                if (nextWord == null)
                {
                    continue;
                } 
                else 
                {
                    return tempWord + " " + nextWord;
                }
            } 
        }
    }
}



string RecoverSentence(string sentence) 
{
    StringBuffer result = new StringBuffer();
    string tempWord = "";
    int lastStart = 0;
    bool ignoreFirstMatch = false;
    
    for (int i = 0; i < sentence.Length; i++) 
    {
        tempWord += sentence[i];
        
        if (isWord(tempWord))
        {
            if (ignoreFirstMatch) 
            {
                ignoreFirstMatch = false;
                continue;
            }
        
            result.Append(tempWord);
            tempWord = "";
            lastStart = i - tempWord.Length;
            
            if (i < sentence.Length - 1) 
            {
                result.Append(" ");
            }
        }
        //we hit the end without a valid word, retry last one 
        else if (i == sentence.Lengh - 1) 
        {
            ignoreFirstMatch = true;
            i = lastStart;
        }       
    }
    
    return result.ToString();
}
 */
