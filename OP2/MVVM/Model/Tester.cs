using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OP2.MVVM.Model
{

    public class Tester
    {
        List<Object> _ToTest = new List<Object>();
        public string Log = "";
        public string TestLog = "";

        public Tester(List<Object> toTest)
        {
            _ToTest = toTest;
        }

        public void TestWith(List<Object> ControlList)
        {
            if (_ToTest.Count == ControlList.Count)
            {
                for(int position = 0; position < _ToTest.Count; position++)
                {
                    Type objType = _ToTest[position].GetType();
                    Type ControlobjType = ControlList[position].GetType();
                    if (objType == ControlobjType)
                    {
                        if (IsReadAble(_ToTest[position]))
                        {
                            if (IsComparealbe(ControlList[position]))
                            {
                                FieldInfo[] objFields = objType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                                FieldInfo[] ControlobjFields = ControlobjType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                                for (int Fieldposition = 0; Fieldposition < objFields.Length; Fieldposition++)
                                {
                                    if (Equals(objFields[Fieldposition].GetValue(_ToTest[position]), ControlobjFields[Fieldposition].GetValue(ControlList[position])))
                                    {

                                    }
                                    else 
                                    { 
                                        Log += $"Mismatch in Object property {objFields[Fieldposition].FieldType} {objFields[Fieldposition].Name} at object {position}\n";
                                        Log += $"Expected - {ControlobjFields[Fieldposition].GetValue(ControlList[position])}\nReceived - {objFields[Fieldposition].GetValue(_ToTest[position])}\n";
                                    }
                                }
                            }
                            else { Log += $"Object at position {position} is UnComparealbe \n"; }
                        }
                        else { Log += $"Object at position {position} is UnReadable \n"; }
                    }
                    else { Log += $"Mismatch in Types at position {position} \n"; }
                    
                }
                if(Log == "")
                {
                    Log += $"Collections is matched!\n";
                }
            }
            else { Log += $"Mismatch in Lenghts of collections!\n"; }
        }
        bool IsReadAble(object obj)
        {
            Type type = obj.GetType();
            object[] attributes = type.GetCustomAttributes(false);

            foreach (Attribute attr in attributes)
            {
                // если атрибут представляет тип AgeValidationAttribute
                if (attr is UnreadableAttribute ageAttribute)
                    return false;
            }
            return true;
        }
        bool IsComparealbe(object obj)
        {
            Type type = obj.GetType();
            object[] attributes = type.GetCustomAttributes(false);

            foreach (Attribute attr in attributes)
            {

                if (attr is NotComparableAttribute ageAttribute)
                    return false;
            }
            return true;
        }
    }
}
