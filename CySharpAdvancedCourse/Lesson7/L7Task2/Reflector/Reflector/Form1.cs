using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Reflector
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;

        public Form1()
        {
            InitializeComponent();
            InitCheckboxList();
        }

        private void InitCheckboxList()
        {
            Array memberInfo = Enum.GetValues(typeof(MemberTypes));
            
            foreach (var member in memberInfo)
            {
                checkedListBox1.Items.Add(member);
            }

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox.Text += "Тип:  " + type + Environment.NewLine;
                    PrintMembers(type);
                }
            }
        }

        private void PrintMembers(Type type)
        {
            MemberInfo[] members = type.GetMembers();
            
            object[] attributes = type.GetCustomAttributes(true);
            
            if (members != null)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        var memberTypeName = checkedListBox1.Items[i].ToString();
                        MemberTypes memberType = (MemberTypes) Enum.Parse(typeof(MemberTypes), memberTypeName);

                        foreach (var member in members)
                        {
                            if (member.MemberType == memberType)
                            {
                                string memberInfo = member.MemberType + " " + member.Name + "\n";

                                textBox.Text += memberInfo + Environment.NewLine;
                                
                                
                                
                                
                                
                            }
                        }
                    }
                }
            }
            textBox.Text += Environment.NewLine;
        }
        
        private void PrintMethods(Type type)
        {
            var methods = type.GetMethods();
            if (methods!=null)
            {
                foreach (var method in methods)
                {
                    string methStr = "Метод:" + method.Name + "\n";
                    var methodBody = method.GetMethodBody();
                    if (methodBody != null)
                    {
                        var byteArray = methodBody.GetILAsByteArray();
                         
                        foreach (var b in byteArray)
                        {
                            methStr += b + ":";
                        }
                    }
                    textBox.Text += methStr+Environment.NewLine;
                }
            }
            textBox.Text += Environment.NewLine;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}