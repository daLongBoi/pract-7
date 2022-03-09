# COM741 Web Applications Development

To edit this project in VSCode you should use Git/Github workflow.

1. Create a Git repository for this project (click the Version Control icon, then click Create Git Repo)
2. Enter a commit message and click Commit & push
3. Then click the Connect to Github button (you may have to login to github and authorise replit to access you Github account if you have not done this before).
4. Next enter a Github repo name (use Practical7)
5. Now go to Github.com and login. Find your new repo and copy the repo url
6. On your personal computer open a command prompt and clone the project from Gitub by using

``` c:> git clone 'repo url'``` 

7. Now you can open this project in VSCode. Use the VSCode git integration to commit any changes you make to to local version and push these changes back to Github.
8. You can then go to your repl and see the updated version.

   
## Practical 7 

*At the end of this practical we will have completed our Student/Ticket management functionality*


1. Complete the following service method so that it verifies that the student who's id is passed as a parameter exists and if so then add the ticket, otherwise return null.
        
    ```
    Ticket CreateTicket(int studentId, string issue) { ... }
    ```
    
    
2. Complete the following outline test project method to verify the operation of the CreateTicket service method. 
    * The arrange section will firstly need to create a student. 
    * Then in the act section use this students id and a dummy ticket issue to create the ticket. 
    * Finally in the assert section verify the ticket returned is not null, that it is active and that its StudentId matches the Id of the student it was created for.  

    ```
    public void Ticket_CreateTicket_ForExistingStudent_ShouldBeCreated { ... }
    ```

3. Complete the following method in the StudentController.cs so that it (a) validates the ticket supplied as a parameter and if valid (2) calls the correct service method to add the ticket, otherwise (3) redisplay the createticket view.

    ```
    [HttpPost]
    IActionResult CreateTicket(Ticket t) { ... }
    ```

4. Make the following amendments to the following views in the Views/Student folder
    * Modify the ```Details.cshtml``` view to include a table to display the student tickets. These are accessed via ```Model.Tickets```. Optional - consider using a partial view to display the tickets.        
    * Complete the ```TicketCreate.cshtml``` view to display a form to enter a ticket issue (form should contain hidden input for StudentId as this should not be editable by the user) and should call the CreateTicket post action.
    * Verify the form works and that the student tickets list contains the new ticket
    * Complete the ```TicketDelete.cshtml``` view by adding a form that contains two hidden input fields. Id (for the ticket id) and StudentId for the id of the student owning the ticket. The form should call the TicketDeleteConfirm action. Review the Delete.chstml view for guidance on using a form for deletion.


5. Complete the following method in the StudentController.cs so that calls the correct service method to delete the ticket based on the supplied ticket id.

    ```
    // POST - delete the selected ticket
    [HttpPost]
    IActionResult DeleteTicketConfirm(int id)
    ```
  
6. Update the student tickets table (found either in the Details.cshtml or _Tickets.cshtml if you created a partial view) so that each table row contains an anchor tag that displays the TicketDelete view.
