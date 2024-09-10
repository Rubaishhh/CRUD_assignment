# Crud Application Using C#
 
Desktop CRUD App Written In C#(.NET Framework)
 
 
## Preview
 ![image](https://github.com/user-attachments/assets/aa3628e9-370f-4b0a-9838-e875d851f4f7)

 
 
 
### Bulit With
- Programming Language: C#(.Net Framework)
- Database: Microsoft SQL Server
- IDE: Visual Studio / VS Code
 
 
## Features(Buttons)
 
- **Insert:** Add new user data to the database.
- **Delete:** Remove existing user data based on userid.
- **Update:** Modify details of a selected user.
- **Reset:** Clear input fields for a new operation.
 
 
## SQL Query
#### Table Design
```bash
  CREATE TABLE [dbo].[user_info] (
    [name]     VARCHAR (50) NULL,
    [password] VARCHAR (50) NOT NULL,
    [userid]   VARCHAR (50) NOT NULL,
    [gender]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_user_info] PRIMARY KEY CLUSTERED ([userid] ASC)
);
```
#### Insert
```bash
"INSERT INTO user_info (name, password, userid, gender) VALUES ('"
+ txt_name.Text + "', '"
+ txt_pass.Text + "', '"
+ txt_uname.Text + "', '"
+ cmb_gen.SelectedItem.ToString() + "')"
```
#### Delete
```bash
"delete from user_info where userid = '"+id+"'"
```
#### Update
```bash
"update user_info set name = '"+ txt_name.Text + "',password = '" + txt_pass.Text + "',userid = '" + txt_uname.Text + "',gender = '" + cmb_gen.SelectedItem.ToString() + "' where userid = '" + id + "'"
```
#### Reset
```bash
txt_name.Text = "";
txt_pass.Text = "";
txt_uname.Text = "";
cmb_gen.SelectedIndex = 0;

```
## Tech Stack
 
**Programming Language:** C# <br><br>
**Database:** SQL Server<br><br>
**Framework:** Windows Forms<br><br>
**UI Components:** <br>
    - Text Box for entering data.<br>
    - Button for response.<br>
    - Data Grid View for displaying and managing data
 
 
## 🛠 Skills
- C#
- .NET Framework
- SQL Server
- Windows Forms Development
