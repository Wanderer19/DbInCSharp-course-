using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFrameworkTask.Model;

namespace EntityFrameworkTask
{
    public partial class DataSender : Form
    {
        private GuestBookEntities guestBook;
        public DataSender()
        {
            InitializeComponent();
            guestBook = new GuestBookEntities();
            AddUniversities();
            UpdateStudents();
        }

        private void AddUniversities()
        {
            var universities = guestBook.universities.ToList();
            foreach (var university in universities)
            {
                universitiesCheckedListBox.Items.Add(string.Format("{0}:{1}", university.id, university.name));
            }
        }

        private void UpdateStudents()
        {
            students.Text = "";
            var studentsRichBox = guestBook.students.ToList();
            foreach (var student in studentsRichBox)
            {
                students.AppendText(string.Format("{0} {1} {2} {3}\n", student.first_name, student.last_name, student.name_group, student.university.name));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text == "")
            {
                MessageBox.Show("Введите имя, пожалуйста!");
                return;
            }

            if (lastNameTextBox.Text == "")
            {
                MessageBox.Show("Введите фамилию, пожалуйста!");
                return;
            }

            if (groupNameTextBox.Text == "")
            {
                MessageBox.Show("Введите группу, пожалуйста!");
                return;
            }

            if (universitiesCheckedListBox.CheckedItems.Count != 1)
            {
                MessageBox.Show("Выберете 1 университет, пожалуйста!");
                return;
            }
            try
            {
                var idUniversity = int.Parse(universitiesCheckedListBox.CheckedItems[0].ToString().Split(':').First());

                guestBook.students.Add(new student()
                {
                    id = guestBook.students.Count() + 1,
                    first_name = firstNameTextBox.Text,
                    last_name = lastNameTextBox.Text,
                    name_group = groupNameTextBox.Text,
                    id_university = idUniversity
                });
                
                guestBook.SaveChanges();
                UpdateStudents();
                
                MessageBox.Show("Студент успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Студент по каким-то техническим причинам не добавлен добавлен!");
            }
        }
    }
}
