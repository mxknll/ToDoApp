using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Models;
using ToDoApp.DataAccess.Repository;

namespace ToDoApp.BlazorServerUI.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IAssignmentRepository AssignmentRepository { get; set; }

        public List<Assignment> Assignments;

        private string newAssignmentText = string.Empty;
        private bool inputIsValid => string.IsNullOrWhiteSpace(newAssignmentText) == false;

        // Init
        protected override void OnParametersSet()
        {
            Assignments = AssignmentRepository.GetAll().ToList();
        }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                textInput.FocusAsync();
            }

        }

        // Hide tasks marked as 'done'
        private bool hideFinishedTasks = false;

        // Add task textbox
        ElementReference textInput;

        // Methods


        private void AddNewAssignment()
        {
            if (inputIsValid)
            {
                Assignment assignment = new()
                {
                    Text = newAssignmentText
                };

                AssignmentRepository.Insert(assignment);
                AssignmentRepository.Save();

                Assignments = AssignmentRepository.GetAll().ToList();

                newAssignmentText = string.Empty;

                textInput.FocusAsync();
            }

        }

        private void RemoveAssignment(Assignment assignment)
        {
            AssignmentRepository.Delete(assignment.AssignmentId);
            AssignmentRepository.Save();

            Assignments = AssignmentRepository.GetAll().ToList();
        }

        private void UpdateAssignment(Assignment assignment)
        {
            AssignmentRepository.Update(assignment);
            AssignmentRepository.Save();

            Assignments = AssignmentRepository.GetAll().ToList();
        }

        private void RemoveAllFinishedTasks()
        {
            AssignmentRepository.DeleteAllFinishedAssignments();
            AssignmentRepository.Save();

            Assignments = AssignmentRepository.GetAll().ToList();
        }

        // Keyboard input to add task
        private async Task KeyboardEventHandler(KeyboardEventArgs args)
        {
            switch (args.Key)
            {
                case "Enter":
                    if (inputIsValid)
                    {
                        AddNewAssignment();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
