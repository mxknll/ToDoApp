using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Models;

namespace ToDoApp.BlazorServerUI.Components
{
    public partial class AssignmentComponent : ComponentBase 
    {
        [Parameter]
        public Assignment Asgnt { get; set; }


        private string editText = string.Empty;
        private bool inputIsValid => string.IsNullOrWhiteSpace(editText) == false;

        private bool isInEditMode = false;

        ElementReference editInput;

        protected override void OnParametersSet()
        {
            editText = Asgnt.Text;
        }


        private void StartEdit()
        {
            editText = Asgnt.Text;

            isInEditMode = true;

            editInput.FocusAsync();
        }

        private void CancelEdit()
        {
            editText = Asgnt.Text;

            isInEditMode = false;
        }


        private void SubmitEdit()
        {
            if (inputIsValid)
            {
                Asgnt.Text = editText;
                OnUpdate.InvokeAsync(Asgnt);
            }
            isInEditMode = false;
        }

        private void ChangeStatus(string status)
        {
            Asgnt.Status = status;
            OnUpdate.InvokeAsync(Asgnt);
        }

        private string status1 = "new";
        private string status2 = "active";
        private string status3 = "done";

        [Parameter]
        public EventCallback<Assignment> OnRemove { get; set; }

        [Parameter]
        public EventCallback<Assignment> OnUpdate { get; set; }

        // Keyboard input to sumbit or cancel task edit
        private async Task KeyboardEventHandler(KeyboardEventArgs args)
        {
            switch (args.Key)
            {
                case "Enter":
                    if (inputIsValid)
                    {
                        SubmitEdit();
                    }
                    break;
                case "Escape":
                    CancelEdit();

                    //TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                    //MoveFocus(request);
                    break;
                default:
                    break;
            }
        }

        // Cancel input if textbox looses focus and mouse is not within bounds of the corrsponding component

        bool mouseIsInsideComponent;
        void MouseIn()
        {
            mouseIsInsideComponent = true;
        }

        void MouseOut()
        {
            mouseIsInsideComponent = false;
        }

        private void OnExitTextBox()
        {
            if (mouseIsInsideComponent == false)
            {
                CancelEdit();
            }
        }
    }
}
